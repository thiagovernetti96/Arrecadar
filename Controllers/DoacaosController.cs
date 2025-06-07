using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arrecadar.Data;
using Arrecadar.Models;
using Arrecadar.Integração.Interfaces;
using Arrecadar.Dto;
using Arrecadar.ExternalModels;

namespace Arrecadar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoacaosController : ControllerBase
    {
        private readonly ArrecadarContext _context;

        public DoacaosController(ArrecadarContext context)
        {
            _context = context;
        }

        // GET: api/Doacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doacao>>> GetDoacao()
        {
            return await _context.Doacao.ToListAsync();
        }

        // GET: api/Doacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doacao>> GetDoacao(int id)
        {
            var doacao = await _context.Doacao.FindAsync(id);

            if (doacao == null)
            {
                return NotFound();
            }

            return doacao;
        }

        // PUT: api/Doacaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoacao(int id, Doacao doacao)
        {
            if (id != doacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(doacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Doacaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doacao>> PostDoacao(Doacao doacao)
        {
            _context.Doacao.Add(doacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoacao", new { id = doacao.Id }, doacao);
        }

        // DELETE: api/Doacaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoacao(int id)
        {
            var doacao = await _context.Doacao.FindAsync(id);
            if (doacao == null)
            {
                return NotFound();
            }

            _context.Doacao.Remove(doacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoacaoExists(int id)
        {
            return _context.Doacao.Any(e => e.Id == id);
        }

        [HttpPost("realizar")]
        public async Task<ActionResult> RealizarDoacao([FromBody] DoacaoDto dto, [FromServices] IAbacatePayApi abacatePayApi)
        {
            var doacao = new Doacao
            {
                CampanhaId = dto.CampanhaId,
                Valor_Doado = dto.Valor,
                Metodo = Doacao.Metodo_Pagamento.Pix,
                Status = Doacao.Status_Doacao.Pendente,
                Data = DateTime.Now,

            };

            _context.Doacao.Add(doacao);
            await _context.SaveChangesAsync(); // Salva antes para garantir o ID

            var request = new PaymentRequest
            {
                Data = new PaymentRequestData
                {
                    Amount = (int)(doacao.Valor_Doado * 100), // centavos
                    Methods = new List<string> { "PIX" },
                    Frequency = "ONE_TIME",
                    Products = new List<PaymentProductRequest>
            {
                new PaymentProductRequest
                {
                    ExternalId = $"doacao-{doacao.Id}",
                    Quantity = 1
                }
            },
                    Customer = new PaymentCustomerRequest
                    {
                        Metadata = new PaymentCustomerMetadata
                        {
                            Name = dto.Nome,
                            Cellphone = dto.Celular,
                            Email = dto.Email,
                            TaxId = dto.Cpf
                        }
                    }
                }
            };

            var response = await abacatePayApi.CreatePaymentAsync(request);

            doacao.AbacatePayBillId = response.Data.Id;
            doacao.AbacatePayUrl = response.Data.Url;
            doacao.Status = Doacao.Status_Doacao.Processando;
             _context.Doacao.Add(doacao);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                doacao.Id,
                pagamentoUrl = doacao.AbacatePayUrl
            });
        }
    }
}
