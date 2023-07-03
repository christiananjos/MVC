using Site.Data;
using Site.Interfaces;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        
        private readonly IUnitOfWork unitOfWork;

        public UsuarioRepository(IUnitOfWork unitOfWork): base(unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");
        }
    }
}
