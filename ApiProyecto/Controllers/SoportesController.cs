using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Data.Models;

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoportesController : ControllerBase
    {
        private readonly PostVentaContext _context;

        public SoportesController(PostVentaContext context)
        {
            _context = context;
        }

        // GET: api/Soportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Soporte>>> GetSoportes()
        {
            return await _context.Soportes.ToListAsync();
        }

        // GET: api/Soportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Soporte>> GetSoporte(int id)
        {
            var soporte = await _context.Soportes.FindAsync(id);

            if (soporte == null)
            {
                return NotFound();
            }

            return soporte;
        }

        // PUT: api/Soportes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoporte(int id, Soporte soporte)
        {
            if (id != soporte.id)
            {
                return BadRequest();
            }

            _context.Entry(soporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoporteExists(id))
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

        // POST: api/Soportes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Soporte>> PostSoporte(Soporte soporte)
        {
            _context.Soportes.Add(soporte);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SoporteExists(soporte.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSoporte", new { id = soporte.id }, soporte);
        }

        // DELETE: api/Soportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoporte(int id)
        {
            var soporte = await _context.Soportes.FindAsync(id);
            if (soporte == null)
            {
                return NotFound();
            }

            _context.Soportes.Remove(soporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoporteExists(int id)
        {
            return _context.Soportes.Any(e => e.id == id);
        }
    }
}
