using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DieselCarDataAccess.Database
{
    public class DieselCarDbContext : DbContext
    {
        public DieselCarDbContext(DbContextOptions<DieselCarDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<DieselCarTable> DieselCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
