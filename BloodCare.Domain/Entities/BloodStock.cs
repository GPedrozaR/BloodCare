using BloodCare.Domain.Base;
using BloodCare.Domain.Enums;

namespace BloodCare.Domain.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodStock(BloodType bloodType, RhFactor rhFactor, int milliliters)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            Milliliters = milliliters;

            CreatedAt = DateTime.UtcNow;
        }

        public BloodType BloodType { get; private set; }

        public RhFactor RhFactor { get; private set; }

        public int Milliliters { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public void SetUpdatedAt(DateTime date)
        {
            UpdatedAt = date;
        }

        public void UpdateMilliliters(int milliliters)
        {
            Milliliters += milliliters;

            SetUpdatedAt(DateTime.UtcNow);
        }
    }
}
