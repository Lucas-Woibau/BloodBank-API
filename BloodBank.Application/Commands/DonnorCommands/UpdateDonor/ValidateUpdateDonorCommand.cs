using BloodBank.Application.Commands.DonnorCommands.CreateDonor;
using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.DonnorCommands.UpdateDonor
{
    public class ValidateUpdateDonorCommand : IPipelineBehavior<UpdateDonorCommand, ResultViewModel>
    {
        private readonly IDonorRepository _repository;

        public ValidateUpdateDonorCommand(IDonorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var donorExists = await _repository.GetById(request.IdDonor);

            if (donorExists == null)
                return ResultViewModel.Error("Donor not found.");

            var emailInUse = await _repository.DonorEmailExists(request.Email, request.IdDonor);

            if (emailInUse)
                return ResultViewModel.Error("This email has already been registered.");

            return await next();
        }
    }
}
