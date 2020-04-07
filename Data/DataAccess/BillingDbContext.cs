using Common.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
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
        public virtual DbSet<Facture> Factures { get; set; }
        public virtual DbSet<Devis> Devis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
