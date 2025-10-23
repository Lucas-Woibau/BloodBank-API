namespace BloodBank.Domain.Entities
{
    public class Address : BaseEntity
    {
        public Address(string publicPlace, string city, string state, string zIPCode, Donor donor)
            : base()
        {
            PublicPlace = publicPlace;
            City = city;
            State = state;
            ZIPCode = zIPCode;
            Donor = donor;
        }

        public string PublicPlace { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZIPCode { get; private set; }
        public Donor Donor { get; private set; }

        public void Update(string publicPlace, string city, string state, string zIPCode)
        {
            PublicPlace = publicPlace;
            City = city;
            State = state;
            ZIPCode = zIPCode;
        }
    }
}
