using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada2.Models;

namespace ProyectoFinalAplicada2.API
{
    [Produces("application/json")]
    [Route("api/Boletas")]
    public class BoletasController : Controller
    {
        private readonly Context _context;

        public BoletasController(Context context)
        {
            _context = context;
        }

        // GET: api/Boletas
        [HttpGet]
        public IEnumerable<Boleta> GetBoletas()
        {
            return _context.Boletas;
        }

        // GET: api/Boletas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoleta([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var boleta = await _context.Boletas.SingleOrDefaultAsync(m => m.Id == id);

            if (boleta == null)
            {
                return NotFound();
            }

            return Ok(boleta);
        }

        // PUT: api/Boletas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoleta([FromRoute] int id, [FromBody] Boleta boleta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boleta.Id)
            {
                return BadRequest();
            }

            _context.Entry(boleta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletaExists(id))
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

        // POST: api/Boletas
        [HttpPost]
        public async Task<IActionResult> PostBoleta([FromBody] Boleta boleta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Boletas.Add(boleta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoleta", new { id = boleta.Id }, boleta);
        }

        // DELETE: api/Boletas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoleta([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var boleta = await _context.Boletas.SingleOrDefaultAsync(m => m.Id == id);
            if (boleta == null)
            {
                return NotFound();
            }

            _context.Boletas.Remove(boleta);
            await _context.SaveChangesAsync();

            return Ok(boleta);
        }

        private bool BoletaExists(int id)
        {
            return _context.Boletas.Any(e => e.Id == id);
        }
    }
}