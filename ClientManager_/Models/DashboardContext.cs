using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ClientManager_.Models
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions<DashboardContext> options)
            : base(options)
        {
        }

        public DbSet<Dashboard> DashboardItens { get; set; }

    }
}
