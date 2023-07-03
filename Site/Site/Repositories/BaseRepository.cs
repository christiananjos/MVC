using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Interfaces;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly Context _dbContext;


        public BaseRepository(Context context)
        {
            _dbContext = context;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public bool ValidaExistente(T entity)
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
    }
}
