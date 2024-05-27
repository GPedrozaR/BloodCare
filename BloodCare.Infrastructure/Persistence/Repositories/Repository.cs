using BloodCare.Domain.Interfaces;
using BloodCare.Domain.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace BloodCare.Infrastructure.Persistence.Repositories
{
    public class Repository<TDomain, TInfrastructure> : IRepository<TDomain>
        where TDomain : class
        where TInfrastructure : class
    {
        public Repository(IMongoDatabase database, string collectionName, IMapper<TDomain, TInfrastructure> mapper)
        {
            _collection = database.GetCollection<TInfrastructure>(collectionName);
            _mapper = mapper;
        }

        private readonly IMongoCollection<TInfrastructure> _collection;
        private readonly IMapper<TDomain, TInfrastructure> _mapper;

        public async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            var entities = await _collection.Find(Builders<TInfrastructure>.Filter.Empty).ToListAsync();
            return entities.Select(_mapper.ToDomain);
        }

        public async Task<TDomain?> GetByIdAsync(string id)
        {
            var filter = Builders<TInfrastructure>.Filter.Eq("Id", id);
            var entity = await _collection.Find(filter).FirstOrDefaultAsync();
            return entity != null ? _mapper.ToDomain(entity) : null;
        }

        public async Task UpsertAsync(string id, TDomain entity)
        {
            var infrastructureEntity = _mapper.ToInfrastructure(entity);

            var filter = Builders<TInfrastructure>.Filter.Eq("Id", ObjectId.Parse(id));

            var options = new ReplaceOptions { IsUpsert = true };

            await _collection.ReplaceOneAsync(filter, infrastructureEntity, options);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<TInfrastructure>.Filter.Eq("Id", ObjectId.Parse(id));
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<TDomain>> GetAllByQueryAsync(Expression<Func<TInfrastructure, bool>>? filterExpression = null)
        {
            var entities = await _collection.Find(filterExpression).ToListAsync();

            var domainEntities = entities.Select(_mapper.ToDomain).AsQueryable();
            return domainEntities;
        }

        public Task<TDomain> GetFirstOrDefault(Expression<Func<TDomain, bool>>? filterExpression = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TDomain>> GetAllByQueryAsync(Expression<Func<TDomain, bool>>? filterExpression = null)
        {
            var cursor = await _collection.Find(filterExpression).ToListAsync();
            return cursor.Select(_mapper.ToDomain);
        }
    }
}
