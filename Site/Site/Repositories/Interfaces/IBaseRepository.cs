using System.Linq.Expressions;

namespace Site.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate);
        bool IfExistEntity(T entity);
    }
}
