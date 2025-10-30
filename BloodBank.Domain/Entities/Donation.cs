namespace BloodBank.Domain.Entities
{
    public class Donation : BaseEntity
    {
        protected Donation() { }
        public Donation(DateTime donationDate, int quantityMl)
            : base()
        {
            DonationDate = donationDate;
            QuantityMl = quantityMl;
        }

        public int IdDonor { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int QuantityMl { get; private set; }

        public Donor Donor { get; private set; }
    }
}
