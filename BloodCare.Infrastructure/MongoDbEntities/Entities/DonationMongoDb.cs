using BloodCare.Infrastructure.MongoDbEntities.Base;
using MongoDB.Bson;

namespace BloodCare.Infrastructure.MongoDbEntities.Entities
{
    public class DonationMongoDb : BaseEntityMongoDb
    {
        public ObjectId DonorId { get; set; }
        public int Milliliters { get; set; }
    }
}
