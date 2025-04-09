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
    public class CampanhasController : ControllerBase
    {
        private readonly ArrecadarContext _context;

        public CampanhasController(ArrecadarContext context)
        {
            _context = context;
        }

        // GET: api/Campanhas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campanha>>> GetCampanha()
        {
            return await _context.Campanha.ToListAsync();
        }

        // GET: api/Campanhas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campanha>> GetCampanha(int id)
        {
            var campanha = await _context.Campanha.FindAsync(id);

            if (campanha == null)
            {
                return NotFound();
            }

            return campanha;
        }

        // PUT: api/Campanhas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampanha(int id, Campanha campanha)
        {
            if (id != campanha.Id)
            {
                return BadRequest();
            }

            _context.Entry(campanha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampanhaExists(id))
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

        // POST: api/Campanhas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Campanha>> PostCampanha(Campanha campanha)
        {
            _context.Campanha.Add(campanha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampanha", new { id = campanha.Id }, campanha);
        }

        // DELETE: api/Campanhas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampanha(int id)
        {
            var campanha = await _context.Campanha.FindAsync(id);
            if (campanha == null)
            {
                return NotFound();
            }

            _context.Campanha.Remove(campanha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampanhaExists(int id)
        {
            return _context.Campanha.Any(e => e.Id == id);
        }
    }
}
