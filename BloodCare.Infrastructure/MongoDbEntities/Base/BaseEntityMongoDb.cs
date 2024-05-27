using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloodCare.Infrastructure.MongoDbEntities.Base
{
    public abstract class BaseEntityMongoDb
    {
        protected BaseEntityMongoDb()
        {
            Id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }
    }
}
