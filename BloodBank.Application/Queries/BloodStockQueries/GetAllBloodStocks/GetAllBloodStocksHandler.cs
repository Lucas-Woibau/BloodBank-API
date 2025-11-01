using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.BloodStockQueries.GetAllBloodStocks
{
    public class GetAllBloodStocksHandler : IRequestHandler<GetAllBloodStocksQuery, ResultViewModel<List<BloodStockItemViewModel>>>
    {
        private readonly IBloodStockRepository _repository;

        public GetAllBloodStocksHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<BloodStockItemViewModel>>> Handle(GetAllBloodStocksQuery request, CancellationToken cancellationToken)
        {
            var bloodStocks = await _repository.GetAll();

            var models = bloodStocks.Select(BloodStockItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<BloodStockItemViewModel>>.Success(models);
        }
    }
}
