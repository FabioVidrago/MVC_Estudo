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

        public DbSet<MVC_Estudo.Models.Department> Department { get; set; }
    }
}
