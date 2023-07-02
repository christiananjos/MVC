using Site.Data;
using Site.Interfaces;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        IUnitOfWork unitOfWork = new Context();

        public UsuarioRepository(IUnitOfWork unitOfWork)
             : base(unitOfWork)
        {

        }
    }
}
