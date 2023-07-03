using Microsoft.AspNetCore.Mvc;
using Site.Repositories.Interfaces;

namespace Site.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _repository;
        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            //var cliente = new Cliente("Christian", "christiananjos@hotmail.com", "c:...");
           
            //_repository.Add(cliente);

            //var coolestCategory = _repository.Find(cliente.Id);

            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Detalhe()
        {
            return View();
        }

        public IActionResult RemoverConfirmacao()
        {
            return View();
        }
    }
}
