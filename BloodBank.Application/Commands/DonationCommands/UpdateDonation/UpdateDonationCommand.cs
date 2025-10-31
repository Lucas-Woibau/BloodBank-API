using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.DonationCommands.UpdateDonation
{
    public class UpdateDonationCommand : IRequest<ResultViewModel>
    {
        public int IdDonation { get; set; }
        public DateTime DonationDate { get; set; }
        public int QuantityMl { get; set; }
    }
}
