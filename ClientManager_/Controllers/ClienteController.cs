using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientManager_.Models;
using ClientManager_.Services;

namespace ClientManager_.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteContext _context;
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteContext context)
        {
            _context = context;
        }

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> GetClienteAll() =>
            _clienteService.GetClienteAll();

        [HttpGet("{id_cliente}", Name = "GetClienteById")]
        public ActionResult<Cliente> GetClienteById(long id)
        {
            var cliente = _clienteService.GetClienteById(id);

            if (!ClienteExists(id))
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpGet("{CNPJ_cliente}", Name = "GetClienteByCNPJ")]
        public ActionResult<Cliente> GetClienteByCNPJ(string CNPJ)
        {
            var clienteByCNPJ = _clienteService.GetClienteByCNPJ(CNPJ);

            if (!ClienteExists(clienteByCNPJ.Id_cliente))
            {
                return NotFound();
            }

            return clienteByCNPJ;
        }

        [HttpGet("{NomeFantasia_cliente}", Name = "GetClienteByName")]
        public ActionResult<Cliente> GetClienteByName(string name)
        {
            var clienteByName = _clienteService.GetClienteByName(name);

            if (!ClienteExists(clienteByName.Id_cliente))
            {
                return NotFound();
            }

            return clienteByName;
        }

        [HttpPost]
        public ActionResult<Cliente> CreateCliente(Cliente cliente)
        {
            _clienteService.CreateCliente(cliente);

            return CreatedAtRoute("GetCliente", new { id = cliente.Id_cliente.ToString() }, cliente);
        }

        [HttpPut("{id_cliente}")]
        public IActionResult UpdateCliente(long id, Cliente clienteIn)
        {
            var cliente = _clienteService.GetClienteById(id);

            if (!ClienteExists(id))
            {
                return NotFound();
            }

            _clienteService.UpdateCliente(id, clienteIn);

            return NoContent();
        }

        [HttpDelete("{id_cliente}")]
        public IActionResult DeleteCliente(long id)
        {
            var cliente = _clienteService.GetClienteById(id);

            if (!ClienteExists(id))
            {
                return NotFound();
            }

            _clienteService.DeleteCliente(cliente.Id_cliente);

            return NoContent();
        }

        private bool ClienteExists(long id) =>
             _context.Clientes.Any(e => e.Id_cliente == id);

    }
}
