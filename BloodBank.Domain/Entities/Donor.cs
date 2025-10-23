using BloodBank.Domain.Enums;

namespace BloodBank.Domain.Entities
{
    public class Donor : BaseEntity
    {
        public Donor(string name, string email, DateTime birthDate, string gender, double weight, BloodType bloodType, RhFactor rhFactor)
            : base()
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;

            Donations = new List<Donation>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public RhFactor RhFactor { get; private set; }
        public Address Address { get; private set; }
        public List<Donation> Donations { get; private set; }

        public void Update(string name, string email, DateTime birthDate, string gender, double weight, BloodType bloodType, RhFactor rhFactor)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }
    }
}
