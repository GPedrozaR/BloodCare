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
            var donationDomain = new Donation(donationMongo.DonorId.ToString(), donationMongo.Milliliters);
            donationDomain.SetId(donationMongo.Id.ToString());
            donationDomain.SetCreatedAt(donationMongo.CreatedAt);

            return donationDomain;
        }
    }
}
