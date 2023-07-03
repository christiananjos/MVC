using Site.Interfaces;
using Site.Repositories.Interfaces;
using Site.Repositories;
using Site.Services.Interfaces;
using Site.Data;

namespace Site.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IUnitOfWork unitOfWork;
        IBaseRepository<T> _repository;

        public BaseService()
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _repository = new BaseRepository<T>(unitOfWork);
        }

        public T Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<T> List()
        {
            return _repository.List();
        }

        public void Add(T item)
        {
            _repository.Add(item);
            unitOfWork.Save();
        }

        public void Remove(T item)
        {
            _repository.Remove(item);
            unitOfWork.Save();
        }

        public void Edit(T item)
        {
            _repository.Edit(item);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
