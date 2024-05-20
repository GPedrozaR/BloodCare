namespace BloodCare.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : Repository<BloodStock>, IBloodStockRepository
    {
        public BloodStockRepository(IMongoDatabase database)
            : base(database, "BloodStocks") { }
    }
}
