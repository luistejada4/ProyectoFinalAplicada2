using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoFinalAplicada2
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EventosController : Controller
    {
        private readonly Context _context;
        public EventosController(Context context)
        {
            _context = context;
        }
        // GET: api/eventos
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            var eventos = _context.Eventos;

            foreach (var evento in eventos)
            {
                _context.Entry(evento).Collection(b => b.Boletas).Load();
            }
            return eventos;
        }

        // GET api/eventos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var evento = await _context.Eventos.FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null) 
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // POST api/eventos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = evento.Id }, evento);
        }

        // PUT api/eventos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != evento.Id)
            {
                return BadRequest();
            }

            if(_context.Entry(evento).State == EntityState.Detached)
            {
                _context.Eventos.Attach(evento);
            }
            else
            {
                _context.Entry(evento).CurrentValues.SetValues(evento);
                _context.Entry(evento).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!eventoExists(id))
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

        // DELETE api/eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var evento = await _context.Eventos.SingleOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return Ok(evento);

        }

        private bool eventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
