using Microsoft.EntityFrameworkCore;

namespace GasCarDataAccess.Database
{
    public class GasCarDbContext : DbContext
    {

        public GasCarDbContext(DbContextOptions<GasCarDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<GasCarTable> GasCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

