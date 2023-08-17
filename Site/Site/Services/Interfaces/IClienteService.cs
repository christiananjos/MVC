using Site.Models;

namespace Site.Services.Interfaces
{
    public interface IClienteService : IBaseService<Cliente>
    {
        Task<Cliente> GetByName(string nome);
        //Task<bool> LogicalRemove(Cliente cliente);
    }
}
