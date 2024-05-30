using BloodCare.Domain.Entities;
using BloodCare.Domain.Interfaces;
using BloodCare.Infrastructure.MongoDbEntities.Entities;

namespace BloodCare.Infrastructure.Mappers
{
    public class BloodStockMapper : IMapper<BloodStock, BloodStockMongoDb>
    {
        public BloodStockMongoDb ToInfrastructure(BloodStock bloodStock)
        {
            return new BloodStockMongoDb(bloodStock.BloodType, bloodStock.RhFactor, bloodStock.Milliliters);
        }

        public BloodStock ToDomain(BloodStockMongoDb bloodStockMongo)
        {
            var bloodStockDomain = new BloodStock(bloodStockMongo.BloodType, bloodStockMongo.RhFactor, bloodStockMongo.Milliliters);
            bloodStockDomain.SetUpdatedAt(bloodStockMongo.UpdatedAt);
            bloodStockDomain.SetId(bloodStockMongo.Id.ToString());
            
            return bloodStockDomain;
        }
    }
}
