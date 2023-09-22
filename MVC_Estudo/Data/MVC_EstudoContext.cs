using Microsoft.EntityFrameworkCore;

namespace MVC_Estudo.Models
{
    public class MVC_EstudoContext : DbContext
    {
        public MVC_EstudoContext(DbContextOptions<MVC_EstudoContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
