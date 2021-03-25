using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManager_.Models
{
    public class ClientManagerDataBaseSettings : IClientManagerDataBaseSettings
    {
        public string ClienteCollectionName { get; set; }
        public string DashboardCollectionName { get; set; }
        public string EnderecoCollectionName { get; set; }
        public string EstadoCollectionName { get; set; }
        public string ServicoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IClientManagerDataBaseSettings
    {
        string ClienteCollectionName { get; set; }
        string DashboardCollectionName { get; set; }
        string EnderecoCollectionName { get; set; }
        string EstadoCollectionName { get; set; }
        string ServicoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
