using BloodCare.Domain.Entities;
using BloodCare.Domain.Interfaces;
using BloodCare.Domain.Repositories;
using BloodCare.Infrastructure.MongoDbEntities.Entities;
using MongoDB.Driver;

namespace BloodCare.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : Repository<BloodStock, BloodStockMongoDb>, IBloodStockRepository
    {
        public BloodStockRepository(IMongoDatabase database, IMapper<BloodStock, BloodStockMongoDb> mapper)
            : base(database, "BloodStocks", mapper) { }
    }
}
