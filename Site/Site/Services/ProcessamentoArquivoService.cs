using Site.Models;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class ProcessamentoArquivoService : IProcessamentoArquivoService
    {
        public Task<IEnumerable<Transacao>> ProcessaArquivo(IFormFile arquivo)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<bool, string>> ValidaArquivo(string textCNAB)
        {
            throw new NotImplementedException();
        }
    }
}
