using Site.Data;
using Site.Models;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        public LogRepository(Context context) : base(context)
        {
        }
    }
}
