using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
