using Site.Data;
using Site.Interfaces;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public ClienteRepository(IUnitOfWork unitOfWork): base(unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");
        }
    }
}
