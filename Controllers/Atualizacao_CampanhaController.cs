using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arrecadar.Data;
using Arrecadar.Models;

namespace Arrecadar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Atualizacao_CampanhaController : ControllerBase
    {
        private readonly ArrecadarContext _context;

        public Atualizacao_CampanhaController(ArrecadarContext context)
        {
            _context = context;
        }

        // GET: api/Atualizacao_Campanha
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atualizacao_Campanha>>> GetAtualizacao_Campanha()
        {
            return await _context.Atualizacao_Campanha.ToListAsync();
        }

        // GET: api/Atualizacao_Campanha/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atualizacao_Campanha>> GetAtualizacao_Campanha(int id)
        {
            var atualizacao_Campanha = await _context.Atualizacao_Campanha.FindAsync(id);

            if (atualizacao_Campanha == null)
            {
                return NotFound();
            }

            return atualizacao_Campanha;
        }

        // PUT: api/Atualizacao_Campanha/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtualizacao_Campanha(int id, Atualizacao_Campanha atualizacao_Campanha)
        {
            if (id != atualizacao_Campanha.Id)
            {
                return BadRequest();
            }

            _context.Entry(atualizacao_Campanha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Atualizacao_CampanhaExists(id))
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

        // POST: api/Atualizacao_Campanha
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atualizacao_Campanha>> PostAtualizacao_Campanha(Atualizacao_Campanha atualizacao_Campanha)
        {
            _context.Atualizacao_Campanha.Add(atualizacao_Campanha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtualizacao_Campanha", new { id = atualizacao_Campanha.Id }, atualizacao_Campanha);
        }

        // DELETE: api/Atualizacao_Campanha/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtualizacao_Campanha(int id)
        {
            var atualizacao_Campanha = await _context.Atualizacao_Campanha.FindAsync(id);
            if (atualizacao_Campanha == null)
            {
                return NotFound();
            }

            _context.Atualizacao_Campanha.Remove(atualizacao_Campanha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Atualizacao_CampanhaExists(int id)
        {
            return _context.Atualizacao_Campanha.Any(e => e.Id == id);
        }
    }
}
