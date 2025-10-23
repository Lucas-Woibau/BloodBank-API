namespace BloodBank.Domain.Entities
{
    public class Donation : BaseEntity
    {
        public Donation(int idDonor, DateTime donationDate, int quantityMl, Donor donor)
            : base()
        {
            IdDonor = idDonor;
            DonationDate = donationDate;
            QuantityMl = quantityMl;
            Donor = donor;
        }

        public int IdDonor { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int QuantityMl { get; private set; }
        public Donor Donor { get; private set; }
    }
}
