using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.ReportQueries.GetDonationsHistory
{
    public class GetMonthDonationsHistoryQuery : IRequest<ResultViewModel<byte[]>>
    {
    }
}
