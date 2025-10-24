using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure
{
    public class BloodBankDbContext : DbContext
    {
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) : base(options) { }

        public DbSet<Donor> Donors { get; set; }
    }
}
