using System.Linq.Expressions;

namespace PruebaCrudColegio.Infrastructure.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<List<T>> BulkAddAsync(List<T> entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> BulkDeleteAsync(List<T> entity);
    }
}