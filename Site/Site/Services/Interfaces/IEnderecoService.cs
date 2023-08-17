using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Site.Models;

namespace Site.Services.Interfaces
{
    public interface IEnderecoService : IBaseService<Endereco>
    {
        Task<Endereco> GetEnderecoPorCEP(string cep);
    }
}
