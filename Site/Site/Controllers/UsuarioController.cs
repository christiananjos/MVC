using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services;
using Site.Services.Interfaces;
using System.Data;

namespace Site.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioService _service;

        public UsuarioController() => _service = new UsuarioService(ModelState);
        #region Actions
        public ActionResult Index()
        {
            return View(_service.List());
        }

        public ViewResult Details(Guid id)
        {
            return View(_service.List()
                .Where(r => r.Id == id)
                .First());
        }

        public ActionResult Create()
        {
            //ViewBag.ApplicationId = new SelectList(_applicationService.List(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (_service.ValidarExistente(usuario))
            {
                _service.Add(usuario);
                return RedirectToAction("Index");
            }

            //ViewBag.ApplicationId = new SelectList(_applicationService.List(), "Id", "Name");
            
            return View(usuario);
        }

        public ActionResult Edit(int id)
        {
            var role = _service.Find(id);
            //ViewBag.ApplicationId = new SelectList(_applicationService.List(), "Id", "Name", role.ApplicationId);
            
            return View(_service.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (_service.ValidarExistente(usuario))
            {
                _service.Edit(usuario);
                return RedirectToAction("Index");
            }

            //ViewBag.ApplicationId = new SelectList(_applicationService.List(), "Id", "Name", role.ApplicationId);
            return View(usuario);
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }
    }
}
