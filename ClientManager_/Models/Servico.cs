using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManager_.Models
{
    public class Servico
    {
        public long Id_servico { get; set; }
        public Cliente Cliente_servico { get; set; }
        public DateTime Data_servico { get; set; }
        public double Valor_servico { get; set; }
        public string Identificacao_servico { get; set; }
    }
}
