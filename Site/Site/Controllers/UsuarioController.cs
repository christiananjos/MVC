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
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult GetById(Guid id)
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(Usuario usuario)
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            return Ok();
        }
        #endregion
    }
}
