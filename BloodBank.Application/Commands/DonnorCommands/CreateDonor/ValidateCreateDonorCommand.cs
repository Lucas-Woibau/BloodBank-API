using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonnorCommands.CreateDonor
{
    public class ValidateCreateDonorCommand : IPipelineBehavior<CreateDonorCommand, ResultViewModel<int>>
    {
        private IDonorRepository _repository;
        public ValidateCreateDonorCommand(IDonorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonorCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var donorEmailExists = await _repository.DonorEmailExists(request.Email, null);

            if (donorEmailExists)
                return ResultViewModel<int>.Error("This email has already been registered.");

            return await next();
        }
    }
}
