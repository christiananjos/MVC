using Site.Models;

namespace Site.Services.Interfaces
{
    public interface IClienteService : IBaseService<Cliente>, IDisposable
    {
        bool ValidarExistente(Cliente cliente);
    }
}
