using Microsoft.EntityFrameworkCore;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;
using System.Linq.Expressions;

namespace PruebaCrudColegio.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PruebaCrudColegioContext _pruebaCrudColegioContext;
        private readonly DbSet<T> _DbSet;

        public Repository(PruebaCrudColegioContext pruebaCrudColegioContext)
        {
            _pruebaCrudColegioContext = pruebaCrudColegioContext;
            _DbSet = _pruebaCrudColegioContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _DbSet.AddAsync(entity);
                await _pruebaCrudColegioContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            try {
                _DbSet.Remove(entity);
                await _pruebaCrudColegioContext.SaveChangesAsync();
                return true;

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return false;
            }
        }
        public async Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            try
            {
                foreach (var include in includes)
                {
                    _DbSet.Include(include);
                }

                return await _DbSet.ToListAsync();
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
                return await _DbSet.Where(predicate).ToListAsync();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                foreach (var include in includes)
                {
                    _DbSet.Include(include);
                }

                return await _DbSet.FindAsync(id);
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
