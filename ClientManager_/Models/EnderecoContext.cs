using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ClientManager_.Models
{
    public class EnderecoContext : DbContext
    {
        public EnderecoContext(DbContextOptions<EnderecoContext> options)
            : base(options)
        {
        }

        public DbSet<Endereco> Enderecos { get; set; }
    }
}
