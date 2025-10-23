using BloodBank.Domain.Enums;

namespace BloodBank.Domain.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodStock(BloodType bloodType, RhFactor rhFactor, int quantityMl)
            : base()
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityMl = quantityMl;
        }

        public BloodType BloodType { get; private set; }
        public RhFactor RhFactor { get; private set; }
        public int QuantityMl { get; private set; }

        public void Update(BloodType bloodType, RhFactor rhFactor, int quantityMl)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityMl = quantityMl;
        }
    }
}
