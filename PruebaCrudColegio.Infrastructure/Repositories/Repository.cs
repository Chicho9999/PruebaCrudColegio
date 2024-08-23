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
                _pruebaCrudColegioContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return entity;
        }

        public bool Delete(T entity)
        {
            try {
                _DbSet.Remove(entity);
                _pruebaCrudColegioContext.SaveChanges();
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

        public T? GetById(Guid id)
        {
            try
            {
                return _DbSet.Find(id);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public T Update(T entity)
        {
            try
            {
                _pruebaCrudColegioContext.Entry(entity).State = EntityState.Modified;
                _pruebaCrudColegioContext.SaveChanges();
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
