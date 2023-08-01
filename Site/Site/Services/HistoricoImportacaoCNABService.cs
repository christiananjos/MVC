using Site.Interfaces;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class HistoricoImportacaoCNABService : IHistoricoImportacaoCNABService
    {
        public IUnitOfWork _unitOfWork;

        public HistoricoImportacaoCNABService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Add(HistoricoImportacaoCNAB entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HistoricoImportacaoCNAB>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<HistoricoImportacaoCNAB> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(HistoricoImportacaoCNAB entity)
        {
            throw new NotImplementedException();
        }
    }
}
