using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.DonorQueries.GetDonationsHistory
{
    public class GetDonationsHistoryQuery : IRequest<ResultViewModel<List<DonationItemViewModel>>>
    {
        public int IdDonor { get; set; }

        public GetDonationsHistoryQuery(int idDonor)
        {
            IdDonor = idDonor;
        }
    }

}
