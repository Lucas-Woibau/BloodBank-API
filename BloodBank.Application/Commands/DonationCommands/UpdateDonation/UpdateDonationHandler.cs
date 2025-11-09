using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonationCommands.UpdateDonation
{
    public class UpdateDonationHandler : IRequestHandler<UpdateDonationCommand, ResultViewModel>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IBloodStockRepository _bloodStockRepository;
        public UpdateDonationHandler(IDonationRepository repository, IBloodStockRepository bloodStockRepository)
        {
            _donationRepository = repository;
            _bloodStockRepository = bloodStockRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepository.GetById(request.IdDonation);

            if (donation == null)
                return ResultViewModel.Error("Donation not found.");

            donation.Update(request.DonationDate, request.QuantityMl);
            
            await _donationRepository.Update(donation);

            return ResultViewModel.Success();
        }
    }
}
