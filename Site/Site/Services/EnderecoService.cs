using Site.Interfaces;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class EnderecoService: IEnderecoService
    {
        public IUnitOfWork _unitOfWork;

        public EnderecoService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> Add(Endereco entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Enderecos.Add(entity);

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
                var enderecoQuery = await _unitOfWork.Enderecos.GetById(id);
                
                if (enderecoQuery != null)
                {
                    _unitOfWork.Enderecos.Delete(enderecoQuery);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Endereco>> GetAll()
        {
            var enderecos = await _unitOfWork.Enderecos.GetAll();

            return enderecos;
        }

        public async Task<Endereco> GetById(Guid id)
        {
            if (id.ToString() != null)
            {
                var enderecoQuery = await _unitOfWork.Enderecos.GetById(id);

                if (enderecoQuery != null)
                    return enderecoQuery;

            }
            return null;
        }

        public async Task<bool> Update(Endereco entity)
        {
            if (entity != null)
            {
                var enderecoQuery = await _unitOfWork.Enderecos.GetById(entity.Id);

                if (enderecoQuery != null)
                {
                    enderecoQuery.ClienteId = entity.ClienteId;
                    enderecoQuery.Logradouro = entity.Logradouro;
                    enderecoQuery.Numero = entity.Numero;
                    enderecoQuery.Complemento = entity.Complemento;
                    enderecoQuery.CEP = entity.CEP;
                    enderecoQuery.UF = entity.UF;
                    enderecoQuery.Estado = entity.Estado;

                    _unitOfWork.Enderecos.Update(enderecoQuery);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
