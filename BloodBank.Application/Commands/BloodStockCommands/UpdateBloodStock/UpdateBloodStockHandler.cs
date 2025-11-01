using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.BloodStockCommands.UpdateBloodStock
{
    public class UpdateBloodStockHandler : IRequestHandler<UpdateBloodStockCommand, ResultViewModel>
    {
        private readonly IBloodStockRepository _repository;

        public UpdateBloodStockHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = await _repository.GetById(request.IdBloodStock);

            if (bloodStock == null)
                return ResultViewModel.Error("Blood Stock not found.");

            bloodStock.Update(request.BloodType, request.RhFactor, request.QuantityMl);
            await _repository.Update(bloodStock);

            return ResultViewModel.Success();
        }
    }
}
