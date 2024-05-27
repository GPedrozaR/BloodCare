using BloodCare.Domain.Entities;
using BloodCare.Domain.Enums;
using BloodCare.Infrastructure.MongoDbEntities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloodCare.Infrastructure.MongoDbEntities.Entities
{
    public class DonorMongoDb : BaseEntityMongoDb
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateOfBirth { get; set; }

        [BsonRepresentation(BsonType.String)]
        public BloodType BloodType { get; set; }

        [BsonRepresentation(BsonType.String)]
        public RhFactor RhFactor { get; set; }

        [BsonRepresentation(BsonType.String)]
        public DonorSituation Situation { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; }

        public Address Address { get; set; }
    }
}
    
