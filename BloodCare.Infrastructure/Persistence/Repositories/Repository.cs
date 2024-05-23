using System.Linq.Expressions;

namespace BloodCare.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        private readonly IMongoCollection<T> _collection;


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(Builders<T>.Filter.Empty).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByQueryAsync(Expression<Func<T, bool>> filterExpression)
        {
            return await _collection.Find(Builders<T>.Filter.Where(filterExpression)).ToListAsync();
        }

        public async Task<T> GetFirstOrDefaultByQueryAsync(Expression<Func<T, bool>> filterExpression)
        {
            return await _collection.Find(Builders<T>.Filter.Where(filterExpression)).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(filter);
        }

        
    }
}
