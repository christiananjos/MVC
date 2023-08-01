using Site.Data;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class UsuarioVerificacaoRepository : BaseRepository<UsuarioVerificacao>, IUsuarioVerificacaoRepository
    {
        public UsuarioVerificacaoRepository(Context context) : base(context)
        {
        }
    }
}
