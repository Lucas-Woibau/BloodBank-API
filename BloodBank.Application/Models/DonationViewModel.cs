using BloodBank.Domain.Entities;

namespace BloodBank.Application.Models
{
    public class DonationViewModel
    {
        public DonationViewModel(int idDonor, DateTime donationDate, int quantityMl, DonorViewModel donor)
        {
            IdDonor = idDonor;
            DonationDate = donationDate;
            QuantityMl = quantityMl;
            Donor = donor;
        }

        public int IdDonor { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int QuantityMl { get; private set; }

        public DonorViewModel Donor { get; private set; }

        public static DonationViewModel FromEntity(Donation entity)
            => new(entity.IdDonor, entity.DonationDate, entity.QuantityMl, new DonorViewModel(entity.Donor.Name, entity.Donor.BloodType));
    }
}
