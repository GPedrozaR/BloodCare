using BloodCare.Domain.Base;
using BloodCare.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloodCare.Domain.Entities
{
    public class Donor : BaseEntity
    {
        public Donor(string fullName, string email, DateTime dateOfBirth, string cpf, string gender, double weight, BloodType bloodType, RhFactor rhFactor, Address address)
        {
            FullName = fullName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Cpf = cpf;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Address = address;

            CreatedAt = DateTime.Now;
            Situation = DonorSituation.Active;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateOfBirth { get; private set; }

        [BsonRepresentation(BsonType.String)]
        public BloodType BloodType { get; private set; }

        [BsonRepresentation(BsonType.String)]
        public RhFactor RhFactor { get; private set; }

        [BsonRepresentation(BsonType.String)]
        public DonorSituation Situation { get; private set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; private set; }

        public Address Address { get; set; }
    }
}
