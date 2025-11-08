namespace BloodBank.Domain.Entities
{
    public class Donation : BaseEntity
    {
        protected Donation() { }
        public Donation(int idDonor, DateTime donationDate, int quantityMl)
            : base()
        {
            IdDonor = idDonor;
            DonationDate = donationDate;
            QuantityMl = quantityMl;
        }

        public int IdDonor { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int QuantityMl { get; private set; }

        public Donor Donor { get; private set; }

        public bool HasValidQuantity() 
            => QuantityMl >= 420 && QuantityMl <= 470;

        public void Update(DateTime donationDate, int quantityMl)
        {
            DonationDate = donationDate;
            QuantityMl = quantityMl;
        }
    }
}
