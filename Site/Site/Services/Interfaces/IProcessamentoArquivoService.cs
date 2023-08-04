namespace Site.Services.Interfaces
{
    public interface IProcessamentoArquivoService
    {
        Task<Dictionary<bool, string>> ProcessaArquivoPorCNABId(string nomeArquivo);
        Task<Dictionary<bool, string>> ValidaArquivo(IEnumerable<string> linhasCNAB);
    }
}
