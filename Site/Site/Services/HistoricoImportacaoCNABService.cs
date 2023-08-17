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

        public async Task<bool> Add(HistoricoImportacaoCNAB entity)
        {
            if (entity != null)
            {
                entity.CreatedAt = DateTime.Now;

                await _unitOfWork.HistoricoImportacoes.Add(entity);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (id.ToString() != null)
            {
                var historico = await _unitOfWork.HistoricoImportacoes.GetById(id);

                if (historico != null)
                {
                    historico.RemovedAt = DateTime.Now;

                    _unitOfWork.HistoricoImportacoes.Delete(historico);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<HistoricoImportacaoCNAB>> GetAll()
        {
            var historicos = await _unitOfWork.HistoricoImportacoes.GetAll();

            return historicos;
        }

        public async Task<HistoricoImportacaoCNAB> GetById(Guid id)
        {
            var historico = await _unitOfWork.HistoricoImportacoes.GetById(id);
            return historico;
        }

        public async Task<bool> Update(HistoricoImportacaoCNAB entity)
        {
            if (entity != null)
            {
                var historico = await _unitOfWork.HistoricoImportacoes.GetById(entity.Id);

                if (historico != null)
                {
                    historico.NomeArquivo = entity.NomeArquivo;
                    historico.Usuario = entity.Usuario;
                    historico.UpdateAt = DateTime.Now;

                    _unitOfWork.HistoricoImportacoes.Update(historico);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<Dictionary<bool, string>> ProcessaArquivoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<bool, string>> ProcessaArquivoPorNome(string nomeArquivo)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<bool, string>> ProcessaTodosArquivos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogicalRemove(HistoricoImportacaoCNAB entity)
        {
            throw new NotImplementedException();
        }
    }
}
