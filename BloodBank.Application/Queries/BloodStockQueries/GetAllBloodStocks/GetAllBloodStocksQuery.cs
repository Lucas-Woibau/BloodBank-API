using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.BloodStockQueries.GetAllBloodStocks
{
    public class GetAllBloodStocksQuery : IRequest<ResultViewModel<List<BloodStockItemViewModel>>>
    {
    }
}
