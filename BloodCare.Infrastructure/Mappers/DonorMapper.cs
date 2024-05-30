using BloodCare.Domain.Entities;
using BloodCare.Domain.Interfaces;
using BloodCare.Infrastructure.MongoDbEntities.Entities;
using MongoDB.Bson;

namespace BloodCare.Infrastructure.Mappers
{
    public class DonorMapper : IMapper<Donor, DonorMongoDb>
    {
        public DonorMongoDb ToInfrastructure(Donor donor)
        {
            return new DonorMongoDb
            {
                FullName = donor.FullName,
                Email = donor.Email,
                Cpf = donor.Cpf,
                Gender = donor.Gender,
                Weight = donor.Weight,
                DateOfBirth = donor.DateOfBirth,
                BloodType = donor.BloodType,
                RhFactor = donor.RhFactor,
                Situation = donor.Situation,
                UpdatedAt = donor.UpdatedAt,
                Address = donor.Address
            };
        }

        public Donor ToDomain(DonorMongoDb donorMongo)
        {
            var donorDomain = new Donor(
                donorMongo.FullName,
                donorMongo.Email,
                donorMongo.DateOfBirth,
                donorMongo.Cpf,
                donorMongo.Gender,
                donorMongo.Weight,
                donorMongo.BloodType,
                donorMongo.RhFactor,
                donorMongo.Address
            );

            donorDomain.SetId(donorMongo.Id.ToString());
            donorDomain.SetCreatedAt(donorMongo.CreatedAt);
            donorDomain.SetUpdatedAt(donorMongo.UpdatedAt);
            donorDomain.SetSituation(donorMongo.Situation);

            return donorDomain;
        }
    }
}

