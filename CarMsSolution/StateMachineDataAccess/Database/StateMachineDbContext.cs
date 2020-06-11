using Microsoft.EntityFrameworkCore;

namespace StateMachineDataAccess.Database
{
    public class StateMachineDbContext : DbContext
    {
        public StateMachineDbContext(DbContextOptions<StateMachineDbContext> options)
            : base(options)
        {

        }

        public DbSet<StateMachineTable> StateMachines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
