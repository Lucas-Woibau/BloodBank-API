using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.DonationsQueries.GetDonationById
{
    public class GetDonationByIdQuery : IRequest<ResultViewModel<DonationViewModel>>
    {
        public GetDonationByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class GetDonationByIdHandler : IRequestHandler<GetDonationByIdQuery, ResultViewModel<DonationViewModel>>
    {
        private readonly IDonationRepository _repository;
        public GetDonationByIdHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<DonationViewModel>> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetById(request.Id);

            if (donation == null)
                return ResultViewModel<DonationViewModel>.Error("Donation not found.");

            var model = DonationViewModel.FromEntity(donation);

            return ResultViewModel<DonationViewModel>.Success(model);
        }
    }
}
