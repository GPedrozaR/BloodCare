using System.Linq.Expressions;

namespace BloodCare.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllByQueryAsync(Expression<Func<T, bool>>? filterExpression = default);
        Task<T> GetFirstByQueryAsync(Expression<Func<T, bool>>? filterExpression = default);
        Task<T> GetByIdAsync(string id);
        Task UpdateAsync(string id, T entity);
        Task InsertAsync(T entity);
        Task DeleteAsync(string id);
    }
}
