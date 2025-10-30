using BloodBank.Application.Models;
using BloodBank.Domain.Enums;
using MediatR;

namespace BloodBank.Application.Queries.DonorQueries.GetAllDonors
{
    public class GetAllDonorsQuery : IRequest<ResultViewModel<List<DonorItemViewModel>>>
    {
    }
}
