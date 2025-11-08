using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.BloodStockCommands.CreateBloodStock
{
    public class ValidateCreateBloodStockCommand : IPipelineBehavior<CreateBloodStockCommand, ResultViewModel<int>>
    {
        private readonly IBloodStockRepository _repository;

        public ValidateCreateBloodStockCommand(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateBloodStockCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsByBloodType(request.BloodType);

            if (exists)
                return ResultViewModel<int>.Error("This blood type already has a registered stock.");

            return await next();
        }
    }
}
