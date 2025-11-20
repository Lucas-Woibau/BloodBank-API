using BloodBank.Domain.Entities;
using BloodBank.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence
{
    public class BloodBankDbContext : DbContext
    {
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) : base(options) { }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<BloodStock> BloodStock { get; set; }
        public DbSet<Donation> Donations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BloodBankDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
