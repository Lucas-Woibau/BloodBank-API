using BloodBank.Domain.Entities;
using BloodBank.Domain.Enums;

namespace BloodBank.Application.Models
{
    public class BloodStockViewModel
    {
        public BloodStockViewModel(BloodType bloodType, RhFactor rhFactor, int quantityMl)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityMl = quantityMl;
        }

        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int QuantityMl { get; set; }

        public static BloodStockViewModel FromEntity(BloodStock entity)
            => new(entity.BloodType, entity.RhFactor, entity.QuantityMl);
    }
}
