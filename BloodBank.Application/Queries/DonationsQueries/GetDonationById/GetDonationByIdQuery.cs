using BloodBank.Application.Models;
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
}
