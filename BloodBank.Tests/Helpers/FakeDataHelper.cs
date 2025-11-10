using BloodBank.Domain.Entities;
using BloodBank.Domain.Enums;
using BloodBank.Domain.ValueObjects;
using Bogus;
using static Bogus.DataSets.Name;

namespace BloodBank.Tests.Helpers
{
    public class FakeDataHelper
    {
        private static readonly Faker _faker = new();

        public static Donor CreateFakerDonorV1()
        {
            var name = _faker.Name.FullName();
            var email = _faker.Internet.Email();
            var age = _faker.Random.Int(18, 65);
            var birthDate = DateTime.Today.AddYears(-age).AddDays(_faker.Random.Int(-365, 0));
            var gender = _faker.PickRandom<Gender>().ToString();
            var weight = _faker.Random.Double(50, 120);
            var bloodType = _faker.PickRandom<BloodType>();
            var rhFactor = _faker.PickRandom<RhFactor>();
            var address = new Address(_faker.Address.StreetName(), _faker.Address.City(), 
                _faker.Address.State(), _faker.Address.ZipCode());

            return new Donor(
                name,
                email,
                birthDate,
                gender,
                weight,
                bloodType,
                rhFactor,
                address
                );
        }
    }
}
