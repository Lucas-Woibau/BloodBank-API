using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.BloodStockQueries.GetBloodStockById
{
    public class GetBloodStockByIdQuery : IRequest<ResultViewModel<BloodStockViewModel>>
    {
        public GetBloodStockByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
