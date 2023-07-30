using Site.Models;

namespace Site.Services.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Task<Usuario> GetByName(string nome);
        Task<bool> LogicalRemove(Usuario user);
        Task<IEnumerable<Usuario>> GetAllActives();
    }
}
