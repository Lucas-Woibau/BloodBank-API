using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonationCommands.UpdateDonation
{
    public class UpdateDonationHandler : IRequestHandler<UpdateDonationCommand, ResultViewModel>
    {
        private readonly IDonationRepository _repository;
        public UpdateDonationHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(request.IdDonation);

            if (donation == null)
                return ResultViewModel.Error("Donation not found.");

            donation.Update(request.DonationDate, request.QuantityMl);
            
            await _repository.Update(donation);

            return ResultViewModel.Success();
        }
    }
}
