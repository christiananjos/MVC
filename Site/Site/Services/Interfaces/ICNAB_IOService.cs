namespace Site.Services.Interfaces
{
    public interface ICNAB_IOService
    {
        void CriaDiretoriosPrincipais();
        void UploadEntrada(IFormFile file, string nomeArquivo);
        void MoveArquivoSaida(string nomeArquivo);
        void MoveArquivoErro(string nomeArquivo);
        Task<IEnumerable<string>> LeCNABEntradaPorNomeArquivo(string nomeArquivo);
    }
}
