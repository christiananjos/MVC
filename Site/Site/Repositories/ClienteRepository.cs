using Site.Data;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(Context dbContext) : base(dbContext)
        {

        }

        //public async Task<IEnumerable<Cliente>> GetAllActives() => await _dbContext.Set<Cliente>().Where(x => x. == true).ToListAsync();
    }
}
