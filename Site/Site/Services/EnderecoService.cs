using Microsoft.AspNetCore.Mvc.ModelBinding;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class EnderecoService: BaseService<Endereco>, IEnderecoService
    {
        private ModelStateDictionary _modelState;

        public EnderecoService(ModelStateDictionary modelState) => _modelState = modelState;
    }
}
