using BloodCare.Domain.Base;

namespace BloodCare.Domain.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodStock(string bloodType, string rhFactor, int milliliters)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            Milliliters = milliliters;
        }

        public string BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public int Milliliters { get; private set; }
    }
}
