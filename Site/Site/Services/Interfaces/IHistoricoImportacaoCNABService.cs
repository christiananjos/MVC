using Site.Models;

namespace Site.Services.Interfaces
{
    public interface IHistoricoImportacaoCNABService : IBaseService<HistoricoImportacaoCNAB>
    {
        Task<Dictionary<bool, string>> ProcessaArquivoPorId(Guid id);
        Task<Dictionary<bool, string>> ProcessaArquivoPorNome(string nomeArquivo);
        Task<Dictionary<bool, string>> ProcessaTodosArquivos();
    }
}
