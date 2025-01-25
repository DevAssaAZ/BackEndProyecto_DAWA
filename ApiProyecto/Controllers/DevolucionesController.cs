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
    public class DevolucionesController : ControllerBase
    {
        private readonly PostVentaContext _context;

        public DevolucionesController(PostVentaContext context)
        {
            _context = context;
        }

        // GET: api/Devoluciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Devolucione>>> GetDevoluciones()
        {
            return await _context.Devoluciones.ToListAsync();
        }

        // GET: api/Devoluciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Devolucione>> GetDevolucione(int id)
        {
            var devolucione = await _context.Devoluciones.FindAsync(id);

            if (devolucione == null)
            {
                return NotFound();
            }

            return devolucione;
        }

        // PUT: api/Devoluciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevolucione(int id, Devolucione devolucione)
        {
            if (id != devolucione.id)
            {
                return BadRequest();
            }

            _context.Entry(devolucione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevolucioneExists(id))
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

        // POST: api/Devoluciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Devolucione>> PostDevolucione(Devolucione devolucione)
        {
            _context.Devoluciones.Add(devolucione);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DevolucioneExists(devolucione.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDevolucione", new { id = devolucione.id }, devolucione);
        }

        // DELETE: api/Devoluciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevolucione(int id)
        {
            var devolucione = await _context.Devoluciones.FindAsync(id);
            if (devolucione == null)
            {
                return NotFound();
            }

            _context.Devoluciones.Remove(devolucione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DevolucioneExists(int id)
        {
            return _context.Devoluciones.Any(e => e.id == id);
        }
    }
}
