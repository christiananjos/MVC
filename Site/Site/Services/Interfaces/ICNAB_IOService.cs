namespace Site.Services.Interfaces
{
    public interface ICNAB_IOService
    {
        void CriaDiretoriosPrincipais();
        void UploadEntrada(IFormFile file, string nomeArquivo);
        void MoveArquivoSaida(IFormFile file, string nomeArquivo);
        void MoveArquivoErro(IFormFile file, string nomeArquivo);
    }
}
