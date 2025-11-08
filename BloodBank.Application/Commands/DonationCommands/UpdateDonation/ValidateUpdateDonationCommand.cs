using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonationCommands.UpdateDonation
{
    public class ValidateUpdateDonationCommand : IPipelineBehavior<UpdateDonationCommand, ResultViewModel>
    {
        private readonly IDonationRepository _repository;

        public ValidateUpdateDonationCommand(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateDonationCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(request.IdDonation);
            
            if (donation == null)
                return ResultViewModel.Error($"Donation not found.");

            if (!donation.HasValidQuantity())
                return ResultViewModel.Error($"Donation must be between 420 and 470 ml.");

            return await next();
        }
    }
}
