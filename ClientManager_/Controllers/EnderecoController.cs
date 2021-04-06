using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientManager_.Models;


namespace ClientManager_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoContext _context;

        public EnderecoController(EnderecoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Endereco>> GetEnderecoAll()
        {
            var enderecoAll = await _context.Enderecos.FindAsync();
            return enderecoAll;
        }

        [HttpGet("{id_endereco}")]
        public async Task<ActionResult<Endereco>> GetEnderecoById(long id)
        {
            var enderecoById = await _context.Enderecos.FindAsync(id);

            if (enderecoById == null)
            {
                return NotFound();
            }

            return enderecoById;
        }

        [HttpPut("{id_endereco}")]
        public async Task<IActionResult> UpdateEndereco(long id, Endereco endereco)
        {
            if (id != endereco.Id_endereco)
            {
                return BadRequest();
            }

            var updateEndereco = await _context.Enderecos.FindAsync(id);
            if (updateEndereco == null)
            {
                return NotFound();
            }

            updateEndereco.Logradouro_endereco = endereco.Logradouro_endereco;
            updateEndereco.Numero_endereco = endereco.Numero_endereco;
            updateEndereco.Estado_endereco = endereco.Estado_endereco;
            updateEndereco.Numero_endereco = endereco.Numero_endereco;
            updateEndereco.Estado_endereco = endereco.Estado_endereco;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!EnderecoExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Endereco>> CreateEndereco(Endereco endereco)
        {
            var createEndereco = new Endereco
            {
                Logradouro_endereco = endereco.Logradouro_endereco,
                Numero_endereco = endereco.Numero_endereco,
                Estado_endereco = endereco.Estado_endereco,
                Cidade_endereco = endereco.Cidade_endereco,
                Cep_endereco = endereco.Cep_endereco
            };

            _context.Enderecos.Add(createEndereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetEnderecoById),
                new { id = endereco.Id_endereco });
        }

        [HttpDelete("{id_endereco}")]
        public async Task<IActionResult> DeleteEndereco(long id)
        {
            var deleteEndereco = await _context.Enderecos.FindAsync(id);

            if (deleteEndereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(deleteEndereco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoExists(long id) =>
             _context.Enderecos.Any(e => e.Id_endereco == id);
    }
}
