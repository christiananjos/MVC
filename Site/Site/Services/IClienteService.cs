using Site.Models;
using Site.Services.Interfaces;
using System.Data;

namespace Site.Services
{
    public interface IClienteService : IBaseService<Cliente>, IDisposable
    {
    }
}
