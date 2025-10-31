using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonationCommands.DeleteDonation
{
    public class DeleteDonationHanlder : IRequestHandler<DeleteDonationCommand, ResultViewModel>
    {
        private readonly IDonationRepository _repository;

        public DeleteDonationHanlder(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(request.Id);

            if (donation == null)
                return ResultViewModel.Error("Dontation not found.");

            await _repository.Delete(donation.Id);

            return ResultViewModel.Success();
        }
    }
}
