using BloodCare.Domain.Base;

namespace BloodCare.Domain.Entities
{
    public class Donation : BaseEntity
    {
        public Donation(int donorId, DateTime donationDate, int milliliters)
        {
            DonorId = donorId;
            DonationDate = donationDate;
            Milliliters = milliliters;

            CreatedAt = DateTime.Now;
        }

        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int Milliliters { get; private set; }

        public Donor Donor { get; private set; }
    }
}
