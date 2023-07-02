using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public interface IClienteService : IBaseService<Cliente>, IDisposable
    {
        bool ValidarExistente(Cliente cliente);
    }
}
