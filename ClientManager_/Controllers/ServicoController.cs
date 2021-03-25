using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientManager_.Models;

namespace ClientManager_.Controllers
{
    [Route("api/Servico")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoContext _context;

        public ServicoController(ServicoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Servico>> GetServicoAll()
        {
            var servicoAll = await _context.Servicos.FindAsync();
            return servicoAll;
        }

        [HttpGet("{id_servico}")]
        public async Task<ActionResult<Servico>> GetServicoById(long id)
        {
            var servicoById = await _context.Servicos.FindAsync(id);

            if (servicoById == null)
            {
                return NotFound();
            }

            return servicoById;
        }

        [HttpGet("{Cliente_servico}")]
        public async Task<ActionResult<Servico>> GetServicoByCliente(Cliente cliente)
        {
            var servicoByCNPJ = await _context.Servicos.FindAsync(cliente);

            if (servicoByCNPJ == null)
            {
                return NotFound();
            }

            return servicoByCNPJ;
        }

        [HttpPut("{id_servico}")]
        public async Task<IActionResult> UpdateServico(long id, Servico servico)
        {
            if (id != servico.Id_servico)
            {
                return BadRequest();
            }

            var updateServico = await _context.Servicos.FindAsync(id);
            if (updateServico == null)
            {
                return NotFound();
            }

            updateServico.Cliente_servico = servico.Cliente_servico;
            updateServico.Data_servico = servico.Data_servico;
            updateServico.Valor_servico = servico.Valor_servico;
            updateServico.Identificacao_servico = servico.Identificacao_servico;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ServicoExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Servico>> CreateServico(Servico servico)
        {
            var createServico = new Servico
            {
                Cliente_servico = servico.Cliente_servico,
                Data_servico = servico.Data_servico,
                Valor_servico = servico.Valor_servico,
                Identificacao_servico = servico.Identificacao_servico
            };

            _context.Servicos.Add(createServico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetServicoById),
                new { id = servico.Id_servico });
        }

        [HttpDelete("{id_servico}")]
        public async Task<IActionResult> DeleteServico(long id)
        {
            var deleteServico = await _context.Servicos.FindAsync(id);

            if (deleteServico == null)
            {
                return NotFound();
            }

            _context.Servicos.Remove(deleteServico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicoExists(long id) =>
             _context.Servicos.Any(e => e.Id_servico == id);

    }
}
