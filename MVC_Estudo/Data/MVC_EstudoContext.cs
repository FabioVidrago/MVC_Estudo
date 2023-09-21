using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Estudo.Models;

namespace MVC_Estudo.Data
{
    public class MVC_EstudoContext : DbContext
    {
        public MVC_EstudoContext (DbContextOptions<MVC_EstudoContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
