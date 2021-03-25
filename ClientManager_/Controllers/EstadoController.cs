using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientManager_.Models;

namespace ClientManager_.Controllers
{
    [Route("api/Estado")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly EstadoContext _context;

        public EstadoController(EstadoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Estado>> GetEstadoAll()
        {
            var estadoAll = await _context.Estados.FindAsync();
            return estadoAll;
        }

        [HttpGet("{id_estado}")]
        public async Task<ActionResult<Estado>> GetEstadoById(long id)
        {
            var estadoById = await _context.Estados.FindAsync(id);

            if (estadoById == null)
            {
                return NotFound();
            }

            return estadoById;
        }


        [HttpPut("{id_estado}")]
        public async Task<IActionResult> UpdateEstado(long id, Estado estado)
        {
            if (id != estado.Id_estado)
            {
                return BadRequest();
            }

            var updateEstado = await _context.Estados.FindAsync(id);
            if (updateEstado == null)
            {
                return NotFound();
            }

            updateEstado.Descricao_estado = estado.Descricao_estado;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!EstadoExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Estado>> CreateEstado(Estado estado)
        {
            var createEstado = new Estado
            {
                Descricao_estado = estado.Descricao_estado
            };

            _context.Estados.Add(createEstado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetEstadoById),
                new { id = estado.Id_estado });
        }

        [HttpDelete("{id_estado}")]
        public async Task<IActionResult> DeleteEstado(long id)
        {
            var deleteEstado = await _context.Estados.FindAsync(id);

            if (deleteEstado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(deleteEstado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoExists(long id) =>
             _context.Estados.Any(e => e.Id_estado == id);
    }
}
