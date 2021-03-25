using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using ClientManager_.Models;

namespace ClientManager_.Services
{
    public class ClienteService
    {
        private readonly IMongoCollection<Cliente> _clientes;

        public ClienteService (IClientManagerDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _clientes = database.GetCollection<Cliente>(settings.ClienteCollectionName);
        }

        public List<Cliente> GetClienteAll() =>
            _clientes.Find(cliente => true).ToList();

        public Cliente GetClienteById(long id) =>
            _clientes.Find<Cliente>(cliente => cliente.Id_cliente == id).FirstOrDefault();

        public Cliente GetClienteByCNPJ(string CNPJ) =>
            _clientes.Find<Cliente>(cliente => cliente.CNPJ_cliente == CNPJ).FirstOrDefault();

        public Cliente GetClienteByName(string nome) =>
            _clientes.Find<Cliente>(cliente => cliente.NomeFantasia_cliente == nome).FirstOrDefault();

        public Cliente CreateCliente(Cliente cliente)
        {
            _clientes.InsertOne(cliente);
            return cliente;
        }

        public void UpdateCliente(long id, Cliente clienteIn) =>
            _clientes.ReplaceOne(cliente => cliente.Id_cliente == id, clienteIn);

        public void DeleteCliente(long id) =>
            _clientes.DeleteOne(cliente => cliente.Id_cliente == id);




    }
}
