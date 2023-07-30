using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Usuario>> GetAllActives() => await _dbContext.Set<Usuario>().Where(x => x.RemovedAt == null).ToListAsync();
    }
}
