using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService) => _usuarioService = usuarioService;

        #region PAGINAS
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
        public ActionResult Editar(Usuario usuario)
        {
            return View();
        }

        public ActionResult Listar()
        {
            return View();
        }
        #endregion

        #region METODOS
        #endregion
    }
}
