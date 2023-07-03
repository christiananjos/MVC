using Site.Interfaces;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class ClienteService : IClienteService
    {
        public IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> Add(Cliente entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Clientes.Add(entity);

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
                var clienteQuery = await _unitOfWork.Clientes.GetById(id);
                
                if (clienteQuery != null)
                {
                    _unitOfWork.Clientes.Delete(clienteQuery);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            var clientes = await _unitOfWork.Clientes.GetAll();

            return clientes;
        }

        public async Task<Cliente> GetById(Guid id)
        {
            if (id.ToString() != null)
            {
                var clienteQuery = await _unitOfWork.Clientes.GetById(id);

                if (clienteQuery != null)
                    return clienteQuery;

            }
            return null;
        }

        public async Task<bool> Update(Cliente entity)
        {
            if (entity != null)
            {
                var cliente = await _unitOfWork.Clientes.GetById(entity.Id);

                if (cliente != null)
                {
                    cliente.Nome = entity.Nome;
                    cliente.Email = entity.Email;
                    cliente.AvatarPath = entity.AvatarPath;
                    cliente.Enderecos = entity.Enderecos;

                    _unitOfWork.Clientes.Update(cliente);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<bool> ValidarExistente(Cliente cliente)
        {
            if (cliente != null)
            {
                var cli = _unitOfWork.Clientes.ValidaExistente(cliente);
                return cli;

            }

            return false;
        }
    }
}
