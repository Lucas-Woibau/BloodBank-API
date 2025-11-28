using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.ReportQueries.GetTotalQuantityByBloodType
{
    public class GetTotalQuantityByBloodTypeQuery : IRequest<ResultViewModel<byte[]>>
    {
    }
}