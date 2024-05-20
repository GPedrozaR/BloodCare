using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloodCare.Domain.Base
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
    }
}
