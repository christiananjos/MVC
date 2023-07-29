using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Site.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly Context _dbContext;

        public BaseRepository(Context context) => _dbContext = context;

        public async Task Add(T entity) => await _dbContext.Set<T>().AddAsync(entity);
        public void Update(T entity) => _dbContext.Set<T>().Update(entity);
        public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);
        public async Task<T> GetById(Guid id) => await _dbContext.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAll() => await _dbContext.Set<T>().ToListAsync();
        public bool IfExistEntity(T entity)
        {
            if (entity != null)
            {
                var query = _dbContext.Set<T>().Find(entity);

                if (query != null)
                {
                    return true;
                }

            }

            return false;
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate) => await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
    }
}
