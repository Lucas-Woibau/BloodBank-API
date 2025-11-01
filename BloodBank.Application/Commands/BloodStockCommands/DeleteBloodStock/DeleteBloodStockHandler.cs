using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.BloodStockCommands.DeleteBloodStock
{
    public class DeleteBloodStockHandler : IRequestHandler<DeleteBloodStockCommand, ResultViewModel>
    {
        private readonly IBloodStockRepository _repository;

        public DeleteBloodStockHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = await _repository.GetById(request.Id);

            if (bloodStock == null)
                return ResultViewModel.Error("Blood Stock not found!");

            await _repository.Delete(bloodStock.Id);

            return ResultViewModel.Success();
        }
    }
}
