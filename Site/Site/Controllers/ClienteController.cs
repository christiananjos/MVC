using Microsoft.AspNetCore.Mvc;
using Site.Services.Interfaces;

namespace Site.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService service) => _clienteService = service;

        #region PAGINAS
        public IActionResult Index()
        {
            var clientes = _clienteService.GetAll();

            return View(clientes);
        }



        public IActionResult Criar()
        {
            //var cliente = _clienteService.Add(id);

            return View();
        }

        public IActionResult Editar()
        {
            //var cliente = _clienteService.Add(id);

            return View();
        }

        public IActionResult Detalhe()
        {
            //var cliente = _clienteService.GetById(id);

            return View();
        }

        public IActionResult RemoverConfirmacao()
        {
            //var cliente = _clienteService.Add(id);

            return View();
        }
        #endregion

        #region METODOS
        #endregion

    }
}
