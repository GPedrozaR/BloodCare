namespace BloodCare.Domain.Entities
{
    internal class Donation
    {
        public Donation(int donorId, DateTime donationDate, int milliliters, Donor donor)
        {
            DonorId = donorId;
            DonationDate = donationDate;
            Milliliters = milliliters;
            Donor = donor;
        }

        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int Milliliters { get; private set; }
        public Donor Donor { get; private set; }
    }
}
