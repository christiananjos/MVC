using Site.Models;

namespace Site.Services.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Task<Usuario> GetByName(string nome);
    }
}
