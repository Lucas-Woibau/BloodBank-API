using BloodBank.Application.Models;
using BloodBank.Domain.Entities;
using MediatR;

namespace BloodBank.Application.Commands.DonationCommands.CreateDonation
{
    public class CreateDonationCommand : IRequest<ResultViewModel<int>>
    {
        public int IdDonor { get; set; }
        public DateTime DonationDate { get; set; }
        public int QuantityMl { get; set; }

        public Donation ToEntity()
            => new(IdDonor, DonationDate, QuantityMl);
    }
}
