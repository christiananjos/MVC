using Site.Interfaces;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class EnderecoService : IEnderecoService
    {
        public IUnitOfWork _unitOfWork;

        public EnderecoService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> Add(Endereco entity)
        {
            if (entity != null)
            {
                entity.CreatedAt = DateTime.Now;

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
                    enderecoQuery.RemovedAt = DateTime.Now;
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

        public async Task<Endereco> GetEnderecoPorCEP(string cep)
        {
            var addresses = await new Correios.NET.CorreiosService().GetAddressesAsync(cep);

            var retornoEndereco = addresses.First();
            
            var endereco = new Endereco()
            {
                Logradouro = retornoEndereco.Street,
                Bairro = retornoEndereco.District,
                CEP = retornoEndereco.ZipCode.ToString(),
                Cidade = addresses.First().City,
                Estado = addresses.First().State
            };

            return endereco;
        }

        public Task<bool> LogicalRemove(Endereco entity)
        {
            entity.RemovedAt = DateTime.Now;

            return Update(entity);
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
                    enderecoQuery.Bairro = entity.Bairro;
                    enderecoQuery.CEP = entity.CEP;
                    enderecoQuery.Cidade = entity.Cidade;
                    enderecoQuery.Estado = entity.Estado;
                    enderecoQuery.Principal = entity.Principal;
                    enderecoQuery.UpdateAt = DateTime.Now;

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
