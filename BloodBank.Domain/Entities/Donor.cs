using BloodBank.Domain.Enums;
using BloodBank.Domain.ValueObjects;
using System.Net;

namespace BloodBank.Domain.Entities
{
    public class Donor : BaseEntity
    {
        protected Donor() { }
        public Donor(string name, string email, DateTime birthDate, string gender, double weight, BloodType bloodType, RhFactor rhFactor, Address address)
            : base()
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;

            Address = address;
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

        public void Update(string name, string email, DateTime birthDate, string gender, double weight, BloodType bloodType, RhFactor rhFactor, Address address)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Address = address;
        }
    }
}
