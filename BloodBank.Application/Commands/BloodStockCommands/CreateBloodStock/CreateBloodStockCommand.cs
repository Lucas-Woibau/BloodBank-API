using BloodBank.Application.Models;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Enums;
using MediatR;

namespace BloodBank.Application.Commands.BloodStockCommands.CreateBloodStock
{
    public class CreateBloodStockCommand : IRequest<ResultViewModel<int>>
    {
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int QuantityMl { get; set; }

        public BloodStock ToEntity()
            => new(BloodType, RhFactor, QuantityMl);
    }
}
