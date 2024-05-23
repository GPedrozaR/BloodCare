using System.Linq.Expressions;

namespace BloodCare.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllByQueryAsync(Expression<Func<T, bool>> filterExpression);
        Task<T> GetFirstOrDefaultByQueryAsync(Expression<Func<T, bool>> filterExpression);
        Task<T> GetByIdAsync(string id);
        Task AddAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}
