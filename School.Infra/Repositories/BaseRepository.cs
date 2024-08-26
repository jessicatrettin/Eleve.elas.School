using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace School.Infra.Repositories
{
    public class BaseRepository
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        //public async Task Add<T>(IEnumerable<T> entities) where T : class
        //{
        //    foreach (T entity in entities)
        //    {
        //        await _context.Set<T>().AddAsync(entity);
        //    }
        //    await _context.SaveChangesAsync();
        //}

        public async Task<T?> GetEntityBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetEntitiesBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        //public async Task Update<T>(IEnumerable<T> entities) where T : class
        //{
        //    foreach (T entity in entities)
        //    {
        //        _context.Update(entity);
        //    }
        //    await _context.SaveChangesAsync();
        //}

        public async Task Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var result = await _context.Set<T>().Where(predicate).ToListAsync();
            foreach (T entity in result)
            {
                _context.Set<T>().Remove(entity);
            }
            await _context.SaveChangesAsync();
        }
    }
}
