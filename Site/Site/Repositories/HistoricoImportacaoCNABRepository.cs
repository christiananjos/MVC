using Site.Data;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class HistoricoImportacaoCNABRepository : BaseRepository<HistoricoImportacaoCNAB>, IHistoricoImportacaoCNABRepository
    {
        public HistoricoImportacaoCNABRepository(Context context) : base(context)
        {
        }
    }
}
