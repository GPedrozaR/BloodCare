using BloodCare.Domain.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace BloodCare.Domain.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodStock(string bloodType, string rhFactor, int milliliters)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            Milliliters = milliliters;

            CreatedAt = DateTime.UtcNow;
        }

        public string BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public int Milliliters { get; private set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; private set; }
    }
}
