using Site.Models;
using Site.Services.Interfaces;
using System.Data;

namespace Site.Services
{
    public interface IUsuarioService : IBaseService<Usuario>, IDisposable
    {
    }
}
