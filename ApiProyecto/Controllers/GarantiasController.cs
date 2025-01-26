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
    public class GarantiasController : ControllerBase
    {
        private readonly PostVentaContext _context;

        public GarantiasController(PostVentaContext context)
        {
            _context = context;
        }

        // GET: api/Garantias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garantia>>> GetGarantias()
        {
            return await _context.Garantias.ToListAsync();
        }

        // GET: api/Garantias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Garantia>> GetGarantia(int id)
        {
            var garantia = await _context.Garantias.FindAsync(id);

            if (garantia == null)
            {
                return NotFound();
            }

            return garantia;
        }

        // PUT: api/Garantias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarantia(int id, Garantia garantia)
        {
            if (id != garantia.id)
            {
                return BadRequest();
            }

            _context.Entry(garantia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarantiaExists(id))
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

        // POST: api/Garantias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Garantia>> PostGarantia(Garantia garantia)
        {
            _context.Garantias.Add(garantia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GarantiaExists(garantia.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGarantia", new { id = garantia.id }, garantia);
        }

        // DELETE: api/Garantias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarantia(string id)
        {
            var garantia = await _context.Garantias.FindAsync(id);
            if (garantia == null)
            {
                return NotFound();
            }

            _context.Garantias.Remove(garantia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GarantiaExists(int id)
        {
            return _context.Garantias.Any(e => e.id == id);
        }
    }
}
