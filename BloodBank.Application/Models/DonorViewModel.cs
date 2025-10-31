using BloodBank.Domain.Entities;
using BloodBank.Domain.Enums;
using BloodBank.Domain.ValueObjects;

namespace BloodBank.Application.Models
{
    public class DonorViewModel
    {
        public DonorViewModel(string name, BloodType bloodType)
        {
            Name = name;
            BloodType = bloodType;
        }
        public DonorViewModel(string name, string email, DateTime birthDate, string gender, double weight, BloodType bloodType, RhFactor rhFactor, Address address, List<Donation> donations)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Address = address;
            Donations = donations;
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

        public static DonorViewModel FromEntity(Donor donor)
        {
            return new DonorViewModel(donor.Name, donor.Email, donor.BirthDate, donor.Gender,
                donor.Weight, donor.BloodType, donor.RhFactor, donor.Address, donor.Donations);
        }
    }
}

