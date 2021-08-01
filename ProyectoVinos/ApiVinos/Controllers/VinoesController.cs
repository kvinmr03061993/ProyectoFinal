using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiVinos.Data;
using ProyectoVinos.Models;

namespace ApiVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VinoesController : ControllerBase
    {
        private readonly ApiVinosContext _context;

        public VinoesController(ApiVinosContext context)
        {
            _context = context;
        }

        // GET: api/Vinoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vino>>> GetVino()
        {
            return await _context.Vino.ToListAsync();
        }

        // GET: api/Vinoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vino>> GetVino(int id)
        {
            var vino = await _context.Vino.FindAsync(id);

            if (vino == null)
            {
                return NotFound();
            }

            return vino;
        }

        // PUT: api/Vinoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVino(int id, Vino vino)
        {
            if (id != vino.IdVino)
            {
                return BadRequest();
            }

            _context.Entry(vino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VinoExists(id))
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

        // POST: api/Vinoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vino>> PostVino(Vino vino)
        {
            _context.Vino.Add(vino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVino", new { id = vino.IdVino }, vino);
        }

        // DELETE: api/Vinoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVino(int id)
        {
            var vino = await _context.Vino.FindAsync(id);
            if (vino == null)
            {
                return NotFound();
            }

            _context.Vino.Remove(vino);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VinoExists(int id)
        {
            return _context.Vino.Any(e => e.IdVino == id);
        }
    }
}
