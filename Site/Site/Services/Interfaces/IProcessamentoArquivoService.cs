namespace Site.Services.Interfaces
{
    public interface IProcessamentoArquivoService
    {
        Task<Dictionary<bool, string>> ProcessaArquivoPorCNABId(IEnumerable<string> linhasCNAB);
        Task<string> ValidaArquivo(IEnumerable<string> linhasCNAB);
    }
}
