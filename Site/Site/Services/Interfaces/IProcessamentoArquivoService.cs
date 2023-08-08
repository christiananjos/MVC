namespace Site.Services.Interfaces
{
    public interface IProcessamentoArquivoService
    {
        Task<string> ProcessaArquivoCNAB(IEnumerable<string> linhasCNAB);
        Task<string> ValidaArquivo(IEnumerable<string> linhasCNAB);
    }
}
