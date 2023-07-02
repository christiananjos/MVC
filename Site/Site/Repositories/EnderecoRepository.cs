using Site.Data;
using Site.Interfaces;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        IUnitOfWork unitOfWork = new Context();

        public EnderecoRepository(IUnitOfWork unitOfWork)
             : base(unitOfWork)
        {

        }
    }
}
