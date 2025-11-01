using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.BloodStockQueries.GetBloodStockById
{
    public class GetBloodStockByIdHandler : IRequestHandler<GetBloodStockByIdQuery, ResultViewModel<BloodStockViewModel>>
    {
        private readonly IBloodStockRepository _repository;

        public GetBloodStockByIdHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<BloodStockViewModel>> Handle(GetBloodStockByIdQuery request, CancellationToken cancellationToken)
        {
            var bloodStock = await _repository.GetById(request.Id);

            if (bloodStock == null)
                ResultViewModel.Error("Blood Stock not found.");

            var model = BloodStockViewModel.FromEntity(bloodStock);

            return ResultViewModel<BloodStockViewModel>.Success(model);
        }
    }
}
