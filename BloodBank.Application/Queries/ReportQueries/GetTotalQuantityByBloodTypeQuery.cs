using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.ReportQueries
{
    public class GetTotalQuantityByBloodTypeQuery : IRequest<ResultViewModel<byte[]>>
    {
    }
}