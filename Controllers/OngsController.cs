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
    public class OngsController : ControllerBase
    {
        private readonly ArrecadarContext _context;

        public OngsController(ArrecadarContext context)
        {
            _context = context;
        }

        // GET: api/Ongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ong>>> GetOng()
        {
            return await _context.Ong.ToListAsync();
        }

        // GET: api/Ongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ong>> GetOng(int id)
        {
            var ong = await _context.Ong.FindAsync(id);

            if (ong == null)
            {
                return NotFound();
            }

            return ong;
        }

        // PUT: api/Ongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOng(int id, Ong ong)
        {
            if (id != ong.Id)
            {
                return BadRequest();
            }

            _context.Entry(ong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OngExists(id))
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

        // POST: api/Ongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ong>> PostOng(Ong ong)
        {
            _context.Ong.Add(ong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOng", new { id = ong.Id }, ong);
        }

        // DELETE: api/Ongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOng(int id)
        {
            var ong = await _context.Ong.FindAsync(id);
            if (ong == null)
            {
                return NotFound();
            }

            _context.Ong.Remove(ong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OngExists(int id)
        {
            return _context.Ong.Any(e => e.Id == id);
        }
    }
}
