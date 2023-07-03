using Site.Data;
using Site.Interfaces;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(Context dbContext) : base(dbContext)
        {

        }
    }
}
