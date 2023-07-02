using Microsoft.AspNetCore.Mvc.ModelBinding;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private ModelStateDictionary _modelState;

        public ClienteService(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        public bool ValidarExistente(Cliente item)
        {
            if (item.Id.ToString() == null)
            {
                if (List().Where(c => c.Email == item.Email).Count() > 0)
                    _modelState.AddModelError("Email", "Cliente com esse e-mail já cadastrado");
            }

            return _modelState.IsValid;
        }
    }
}
