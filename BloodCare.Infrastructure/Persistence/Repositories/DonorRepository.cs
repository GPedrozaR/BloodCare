namespace BloodCare.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : Repository<Donor>, IDonorRepository
    {
        public DonorRepository(IMongoDatabase database)
            : base(database, "Donors") { }
    }
}
