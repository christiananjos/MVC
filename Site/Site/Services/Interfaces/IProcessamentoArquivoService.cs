using Site.Models;

namespace Site.Services.Interfaces
{
    public interface IProcessamentoArquivoService
    {
        Task<IEnumerable<Transacao>> ProcessaArquivo(IFormFile arquivo);
        Task<Dictionary<bool, string>> ValidaArquivo(string textCNAB);
    }
}
