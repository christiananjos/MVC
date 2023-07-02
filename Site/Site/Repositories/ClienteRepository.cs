using Site.Data;
using Site.Interfaces;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        IUnitOfWork unitOfWork = new Context();

        public ClienteRepository(IUnitOfWork unitOfWork)
             : base(unitOfWork)
        {

        }
    }
}
