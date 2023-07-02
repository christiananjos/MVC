using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public interface IUsuarioService : IBaseService<Usuario>, IDisposable
    {
        bool ValidarExistente(Usuario Usuario);
    }
}
