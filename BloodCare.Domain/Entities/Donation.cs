using BloodCare.Domain.Base;

namespace BloodCare.Domain.Entities
{
    public class Donation : BaseEntity
    {
        public Donation(string donorId, int milliliters)
        {
            DonorId = donorId;
            Milliliters = milliliters;

            CreatedAt = DateTime.Now;
        }

        public string DonorId { get; private set; }
        public int Milliliters { get; private set; }

        public bool ValidateMilliliters()
        {
            return Milliliters is >= 420 and <= 470;
        }
    }
}
