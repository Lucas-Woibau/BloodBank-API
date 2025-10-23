using BloodBank.Domain.Entities;
using BloodBank.Domain.Enums;

namespace BloodBank.Application.Models
{
    public class DonorItemViewModel
    {
        public DonorItemViewModel(string name, string email, BloodType bloodType, RhFactor rhFactor)
        {
            Name = name;
            Email = email;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public BloodType BloodType { get; private set; }
        public RhFactor RhFactor { get; private set; }

        public static DonorItemViewModel FromEntity(Donor donor)
        {
            return new DonorItemViewModel(donor.Name, donor.Email, donor.BloodType, donor.RhFactor);
        }
    }
}
