using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManager_.Models
{
    public class Endereco
    {
        public long Id_endereco { get; set; }
        public string Logradouro_endereco { get; set; }
        public string Numero_endereco { get; set; }
        public string Complemento_endereco { get; set; }
        public Estado Estado_endereco { get; set; }
        public string Cidade_endereco { get; set; }
        public string Cep_endereco { get; set; }
    }
}
