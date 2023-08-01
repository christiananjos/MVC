using Site.Interfaces;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class TransacaoService : ITransacaoService
    {
        public IUnitOfWork _unitOfWork;

        public TransacaoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Add(Transacao entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transacao>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Transacao> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Transacao entity)
        {
            throw new NotImplementedException();
        }
    }
}
