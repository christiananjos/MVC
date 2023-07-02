using Site.Models;

namespace Site.Services.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario>, IDisposable
    {
        bool ValidarExistente(Usuario Usuario);
    }
}
