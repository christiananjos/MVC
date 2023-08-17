namespace Site.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> LogicalRemove(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();

    }
}
