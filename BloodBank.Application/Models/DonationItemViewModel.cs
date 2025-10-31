using BloodBank.Domain.Entities;

namespace BloodBank.Application.Models
{
    public class DonationItemViewModel
    {
        public DonationItemViewModel(int idDonor, DateTime donationDate, int quantityMl)
        {
            IdDonor = idDonor;
            DonationDate = donationDate;
            QuantityMl = quantityMl;
        }

        public int IdDonor { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int QuantityMl { get; private set; }

        public static DonationItemViewModel FromEntity(Donation entity)
            => new(entity.IdDonor, entity.DonationDate, entity.QuantityMl);
    }
}
