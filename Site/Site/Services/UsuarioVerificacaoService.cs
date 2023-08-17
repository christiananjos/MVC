using Site.Interfaces;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class UsuarioVerificacaoService : IUsuarioVerificacaoService
    {
        public IUnitOfWork _unitOfWork;

        public UsuarioVerificacaoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Add(UsuarioVerificacao entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioVerificacao>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioVerificacao> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogicalRemove(UsuarioVerificacao entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UsuarioVerificacao entity)
        {
            throw new NotImplementedException();
        }
    }
}
