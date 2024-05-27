using MongoDB.Bson;
using System.Linq.Expressions;

namespace BloodCare.Domain.Repositories
{
    public interface IRepository<TDomain> where TDomain : class
    {
        Task<IEnumerable<TDomain>> GetAllAsync();
        Task<IEnumerable<TDomain>> GetAllByQueryAsync(Expression<Func<TDomain, bool>>? filterExpression = default);
        Task<TDomain> GetFirstOrDefault(Expression<Func<TDomain, bool>>? filterExpression = default);
        Task<TDomain> GetByIdAsync(string id);
        Task UpsertAsync(string id, TDomain entity);
        Task DeleteAsync(string id);
    }
}
