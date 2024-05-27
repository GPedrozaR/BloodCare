using BloodCare.Domain.Enums;
using BloodCare.Infrastructure.MongoDbEntities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloodCare.Infrastructure.MongoDbEntities.Entities
{
    public class BloodStockMongoDb : BaseEntityMongoDb
    {
        public BloodStockMongoDb(BloodType bloodType, RhFactor rhFactor, int milliliters)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            Milliliters = milliliters;

            CreatedAt = DateTime.UtcNow;
        }

        [BsonRepresentation(BsonType.String)]
        public BloodType BloodType { get; private set; }

        [BsonRepresentation(BsonType.String)]
        public RhFactor RhFactor { get; private set; }

        public int Milliliters { get; private set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; private set; }
    }
}
