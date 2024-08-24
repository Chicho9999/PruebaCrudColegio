using System.Linq.Expressions;

namespace PruebaCrudColegio.Infrastructure.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        T? GetById(Guid id, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}