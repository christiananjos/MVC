using Microsoft.AspNetCore.Mvc.ModelBinding;
using Site.Models;
using Site.Services.Interfaces;
using System.Data;

namespace Site.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private ModelStateDictionary _modelState;

        public UsuarioService(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        public bool ValidarExistente(Usuario item)
        {
            if (item.Id.ToString() == null)
            {
                if (List().Where(c => c.Usernaname == item.Usernaname).Count() > 0)
                    _modelState.AddModelError("Usernaname", "Usuario já cadastrado");
            }

            return _modelState.IsValid;
        }
    }
}
