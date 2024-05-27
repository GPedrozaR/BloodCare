using BloodCare.Domain.Entities;
using BloodCare.Domain.Interfaces;
using BloodCare.Domain.Repositories;
using BloodCare.Infrastructure.MongoDbEntities.Entities;
using MongoDB.Driver;

namespace BloodCare.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : Repository<Donation, DonationMongoDb>, IDonationRepository
    {
        public DonationRepository(IMongoDatabase database, IMapper<Donation, DonationMongoDb> mapper)
            : base(database, "Donations", mapper) { }
    }
}
