using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.DonationsQueries.GetAllDonations
{
    public class GetAllDonationsHanlder : IRequestHandler<GetAllDonationsQuery, ResultViewModel<List<DonationItemViewModel>>>
    {
        private readonly IDonationRepository _repository;
        public GetAllDonationsHanlder(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<DonationItemViewModel>>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
        {
            var donations = await _repository.GetAll();
            
            var model = donations.Select(DonationItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonationItemViewModel>>.Success(model);
        }
    }
}
