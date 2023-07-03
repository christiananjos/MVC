using Site.Models;

namespace Site.Services.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        bool ValidarExistente(Usuario Usuario);
    }
}
