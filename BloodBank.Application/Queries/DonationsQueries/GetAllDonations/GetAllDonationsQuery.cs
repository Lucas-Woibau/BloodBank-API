using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.DonationsQueries.GetAllDonations
{
    public class GetAllDonationsQuery : IRequest<ResultViewModel<List<DonationItemViewModel>>>
    {
    }
}
