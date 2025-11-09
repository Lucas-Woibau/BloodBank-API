using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.BloodStockCommands.CreateBloodStock
{
    public class CreateBloodStockHandler : IRequestHandler<CreateBloodStockCommand, ResultViewModel<int>>
    {
        private readonly IBloodStockRepository _repository;

        public CreateBloodStockHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = request.ToEntity();


            if (bloodStock.VerifyBloodStockQuantity())
                return ResultViewModel<int>.Error("The quantity cannot be negative.");

            var id = await _repository.Add(bloodStock);

            await _repository.Update(bloodStock);

            return ResultViewModel<int>.Success(id);
        }
    }
}
