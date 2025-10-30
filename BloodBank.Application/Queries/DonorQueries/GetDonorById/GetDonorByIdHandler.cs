using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.DonorQueries.GetDonorById
{
    public class GetDonorByIdHandler : IRequestHandler<GetDonorByIdQuery, ResultViewModel<DonorViewModel>>
    {
        private readonly IDonorRepository _repository;

        public GetDonorByIdHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<DonorViewModel>> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.Id);

            if (donor == null)
                ResultViewModel.Error("Donor not found.");

            var model = DonorViewModel.FromEntity(donor);

            return ResultViewModel<DonorViewModel>.Success(model);
        }
    }
}
