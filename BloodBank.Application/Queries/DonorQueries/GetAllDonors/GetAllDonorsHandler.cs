using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.DonorQueries.GetAllDonors
{
    public class GetAllDonorsHandler : IRequestHandler<GetAllDonorsQuery, ResultViewModel<List<DonorItemViewModel>>>
    {
        private readonly IDonorRepository _repository;

        public GetAllDonorsHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<DonorItemViewModel>>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donors = await _repository.GetAll();

            var models = donors.Select(DonorItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonorItemViewModel>>.Success(models);
        }
    }
}
