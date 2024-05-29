using BloodCare.Domain.Entities;
using BloodCare.Domain.Interfaces;
using BloodCare.Infrastructure.MongoDbEntities.Entities;
using MongoDB.Bson;

namespace BloodCare.Infrastructure.Mappers
{
    public class DonationMapper : IMapper<Donation, DonationMongoDb>
    {
        public DonationMongoDb ToInfrastructure(Donation donation)
        {
            return new DonationMongoDb
            {
                DonorId = ObjectId.Parse(donation.DonorId),
                Milliliters = donation.Milliliters
            };
        }

        public Donation ToDomain(DonationMongoDb donationMongo)
        {
            return new Donation(
                donationMongo.DonorId.ToString(),
                donationMongo.Milliliters)
            {
                Id = donationMongo.Id.ToString(),
                CreatedAt = donationMongo.CreatedAt
            };

        }
    }
}
