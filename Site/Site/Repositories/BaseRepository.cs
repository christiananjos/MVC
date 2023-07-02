using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Interfaces;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private Context _context;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _context = (Context)unitOfWork;
        }


        public T Find(int id) => _context.Set<T>().Find(id);

        public IQueryable<T> List() => _context.Set<T>();

        public void Add(T item) => _context.Set<T>().Add(item);

        public void Remove(T item) => _context.Set<T>().Remove(item);

        public void Edit(T item) => _context.Entry(item).State = EntityState.Modified;

        public void Dispose() => _context.Dispose();
    }
}
