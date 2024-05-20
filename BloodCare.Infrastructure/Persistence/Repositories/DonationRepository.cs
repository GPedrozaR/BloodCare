namespace BloodCare.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : Repository<Donation>, IDonationRepository
    {
        public DonationRepository(IMongoDatabase database)
            : base(database, "Donations") { }
    }
}
