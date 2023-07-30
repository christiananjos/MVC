using Microsoft.AspNetCore.Mvc;
using Site.Services.Interfaces;

namespace Site.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
