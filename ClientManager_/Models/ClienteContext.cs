using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ClientManager_.Models
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) 
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
