using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.DonorQueries.GetDonationsHistory
{
    public class GetDonationsHistoryHandler : IRequestHandler<GetDonationsHistoryQuery, ResultViewModel<List<DonationItemViewModel>>>
    {
        private readonly IDonorRepository _repository;

        public GetDonationsHistoryHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<DonationItemViewModel>>> Handle(GetDonationsHistoryQuery request, CancellationToken cancellationToken)
        {
            var donations = await _repository.DonationsHistory(request.IdDonor);
            if (donations == null)
                return ResultViewModel<List<DonationItemViewModel>>.Error("Donations not found");

            var model = donations.Select(DonationItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonationItemViewModel>>.Success(model);
        }
    }
}
