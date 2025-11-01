using BloodBank.Application.Models;
using BloodBank.Domain.Enums;
using MediatR;

namespace BloodBank.Application.Commands.BloodStockCommands.UpdateBloodStock
{
    public class UpdateBloodStockCommand : IRequest<ResultViewModel>
    {
        public int IdBloodStock { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int QuantityMl { get; set; }
    }
}
