using BloodCare.Domain.Interfaces;
using BloodCare.Domain.Repositories;
using BloodCare.Infrastructure.Persistence.Repositories.Expressions;
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
            var filter = Builders<TInfrastructure>.Filter.Eq("Id", ObjectId.Parse(id));

            var entity = await _collection.Find(filter).FirstOrDefaultAsync();
            return entity != null ? _mapper.ToDomain(entity) : null;
        }

        public async Task UpdateAsync(string id, TDomain entity)
        {
            var infrastructureEntity = _mapper.ToInfrastructure(entity);

            var filter = Builders<TInfrastructure>.Filter.Eq("Id", ObjectId.Parse(id));

            await _collection.ReplaceOneAsync(filter, infrastructureEntity);
        }

        public async Task InsertAsync(TDomain entity)
        {
            var infrastructureEntity = _mapper.ToInfrastructure(entity);

            await _collection.InsertOneAsync(infrastructureEntity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<TInfrastructure>.Filter.Eq("Id", ObjectId.Parse(id));
            await _collection.DeleteOneAsync(filter);
        }
        public async Task<IEnumerable<TDomain>> GetAllByQueryAsync(Expression<Func<TDomain, bool>>? filterExpression = default)
        {
            if (filterExpression == null)
                return [];

            var infrastructureFilter = filterExpression.ToInfrastructureExpression<TDomain, TInfrastructure>();

            var list = await _collection.Find(Builders<TInfrastructure>.Filter.Where(infrastructureFilter)).ToListAsync();
            return list.Select(_mapper.ToDomain);
        }

        public async Task<TDomain> GetFirstByQueryAsync(Expression<Func<TDomain, bool>>? filterExpression = default)
        {
            var infrastructureFilter = FilterDefinition<TInfrastructure>.Empty;
            if (filterExpression != null)
                infrastructureFilter = filterExpression.ToInfrastructureExpression<TDomain, TInfrastructure>();

            var firstByQuery = await _collection.Find(infrastructureFilter).FirstOrDefaultAsync();
            return firstByQuery != null ? _mapper.ToDomain(firstByQuery) : null;
        }
    }
}
