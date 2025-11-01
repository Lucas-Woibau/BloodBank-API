using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonnorCommands.UpdateDonor
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel>
    {
        private readonly IDonorRepository _repository;

        public UpdateDonorHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.IdDonor);

            if (donor == null)
                return ResultViewModel.Error("Donor not found.");

            donor.Update
                (request.Name, request.Email, request.BirthDate, request.Gender,
                request.Weight, request.BloodType, request.RhFactor, request.Address);

            await _repository.Update(donor);

            return ResultViewModel.Success();
        }
    }
}
