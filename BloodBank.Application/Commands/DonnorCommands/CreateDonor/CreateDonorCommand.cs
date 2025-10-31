using BloodBank.Application.Models;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Enums;
using BloodBank.Domain.ValueObjects;
using MediatR;

namespace BloodBank.Application.Commands.DonnorCommands.CreateDonor
{
    public class CreateDonorCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; private set; }
        public Address Address { get; set; }

        public Donor ToEntity() =>
            new(Name, Email, BirthDate, Gender, Weight, BloodType, RhFactor, Address);
    }
}
