using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infrastructure.Persistence.Configurations
{
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.HasKey(d => d.Id);

            builder.OwnsOne(d => d.Address);

            builder.HasMany(d => d.Donations)
                   .WithOne()
                   .HasForeignKey(d => d.IdDonor);

            builder.Property(d => d.BloodType)
                   .HasConversion<string>();

            builder.Property(d => d.RhFactor)
                   .HasConversion<string>();
        }
    }
}
