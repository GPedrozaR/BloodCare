using BloodCare.Domain.Entities;
using BloodCare.Domain.Interfaces;
using BloodCare.Domain.Repositories;
using BloodCare.Infrastructure.MongoDbEntities.Entities;
using MongoDB.Driver;

namespace BloodCare.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : Repository<Donor, DonorMongoDb>, IDonorRepository
    {
        public DonorRepository(IMongoDatabase database, IMapper<Donor, DonorMongoDb> mapper)
            : base(database, "Donors", mapper) { }
    }
}
