using Site.Models;
using System.Data;

namespace Site.Repositories.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>, IDisposable
    {
    }
}
