using Microsoft.EntityFrameworkCore;

namespace DieselCarDataAccess.Database
{
    public class DieselCarDbContext : DbContext
    {
        public DieselCarDbContext(DbContextOptions<DieselCarDbContext> options)
            :base(options)
        {

        }

        public virtual DbSet<DieselCarTable> DieselCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
