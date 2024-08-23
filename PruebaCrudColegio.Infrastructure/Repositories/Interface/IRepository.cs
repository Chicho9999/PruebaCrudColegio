using System.Linq.Expressions;

namespace PruebaCrudColegio.Infrastructure.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        T? GetById(Guid id);
        Task<IList<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}