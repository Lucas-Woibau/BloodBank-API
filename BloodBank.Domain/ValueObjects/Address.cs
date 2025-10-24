using BloodBank.Domain.Entities;

namespace BloodBank.Domain.ValueObjects
{
    public class Address
    {
        public Address(string publicPlace, string city, string state, string zIPCode)
            : base()
        {
            PublicPlace = publicPlace;
            City = city;
            State = state;
            ZIPCode = zIPCode;
        }

        public string PublicPlace { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZIPCode { get; private set; }

        public Address Update(string publicPlace, string city, string state, string zipCode)
           => new Address(publicPlace, city, state, zipCode);
    }
}
