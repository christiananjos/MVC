using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Detalhes(Guid id)
        {
            return View();
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Usuario usuario)
        {
            return View();
        }

        public ActionResult Editar(Guid id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            return View();
        }
    }
}
