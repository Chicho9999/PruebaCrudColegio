using System.Linq.Expressions;

namespace PruebaCrudColegio.Infrastructure.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<IList<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}