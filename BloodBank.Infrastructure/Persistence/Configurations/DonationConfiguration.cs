using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infrastructure.Persistence.Configurations
{
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(d => d.Donor)
                .WithMany(d => d.Donations)
                .HasForeignKey(d => d.IdDonor)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
