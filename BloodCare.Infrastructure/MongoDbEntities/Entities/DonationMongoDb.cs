using BloodCare.Infrastructure.MongoDbEntities.Base;

namespace BloodCare.Infrastructure.MongoDbEntities.Entities
{
    public class DonationMongoDb : BaseEntityMongoDb
    {
        public string DonorId { get; set; }
        public int Milliliters { get; set; }
    }
}
