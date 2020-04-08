using Common.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.DataAccess
{
    public class BillingDbContext : DbContext
    {
        public BillingDbContext()
        {
        }

        public BillingDbContext(DbContextOptions<BillingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Estimate> Estimates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
