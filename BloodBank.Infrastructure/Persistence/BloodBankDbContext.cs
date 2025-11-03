using BloodBank.Domain.Entities;
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
            builder
                .Entity<Donor>(e =>
                {
                    e.HasKey(d => d.Id);
                    e.OwnsOne(d => d.Address);
                    e.HasMany(d => d.Donations);
                    e.Property(d => d.BloodType)
                        .HasConversion<string>();
                    e.Property(d => d.RhFactor)
                        .HasConversion<string>();
                });

            builder
                .Entity<Donation>(e =>
                {
                    e.HasKey(d => d.Id);

                    e.HasOne(d => d.Donor)
                        .WithMany(d => d.Donations)
                        .HasForeignKey(d => d.IdDonor)
                        .OnDelete(DeleteBehavior.Cascade);
                });

            builder
                .Entity<BloodStock>(e =>
                {
                    e.HasKey(d => d.Id);
                });


            base.OnModelCreating(builder);
        }
    }
}
