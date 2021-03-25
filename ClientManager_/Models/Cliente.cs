using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClientManager_.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public long Id_cliente { get; set; }

        [BsonElement("CNPJ")]
        public string CNPJ_cliente { get; set; }

        [BsonElement("NomeFantasia")]
        public string NomeFantasia_cliente { get; set; }

        [BsonElement("Endereco")]
        public Endereco Endereco_cliente { get; set; }

    }
}
