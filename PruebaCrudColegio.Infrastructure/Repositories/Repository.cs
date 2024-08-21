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
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
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
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return false;
            }
        }
        public async Task<IList<T>> GetAllAsync()
        {
            try
            {
                return await _pruebaCrudColegioContext.Set<T>().ToListAsync();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public async Task<IList<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _pruebaCrudColegioContext.Set<T>().Where(predicate).ToListAsync();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _pruebaCrudColegioContext.Set<T>().FindAsync(id);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _pruebaCrudColegioContext.Entry(entity).State = EntityState.Modified;
                await _pruebaCrudColegioContext.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
    }
}
