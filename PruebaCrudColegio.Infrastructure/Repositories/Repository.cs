using Microsoft.EntityFrameworkCore;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;
using System.Linq.Expressions;

namespace PruebaCrudColegio.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PruebaCrudColegioContext _pruebaCrudColegioContext;
        public Repository(PruebaCrudColegioContext pruebaCrudColegioContext)
        {
            _pruebaCrudColegioContext = pruebaCrudColegioContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _pruebaCrudColegioContext.Set<T>().AddAsync(entity);
                await _pruebaCrudColegioContext.SaveChangesAsync();
            }
            catch (DbUpdateException Ex)
            {
                Console.WriteLine(Ex.InnerException?.Message);
                throw;
            }

            return entity;
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            try {
                _pruebaCrudColegioContext.Set<T>().Remove(entity);
                await _pruebaCrudColegioContext.SaveChangesAsync();
                return true;

            }
            catch (DbUpdateException Ex)
            {
                Console.WriteLine(Ex.InnerException?.Message);
                return false;
            }
        }
        public async Task<IList<T>> GetAllAsync()
        {
            return await _pruebaCrudColegioContext.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _pruebaCrudColegioContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _pruebaCrudColegioContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _pruebaCrudColegioContext.Entry(entity).State = EntityState.Modified;
            await _pruebaCrudColegioContext.SaveChangesAsync();
            return entity;
        }
    }
}
