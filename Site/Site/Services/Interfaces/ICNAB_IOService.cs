namespace Site.Services.Interfaces
{
    public interface ICNAB_IOService
    {
        Task UploadEntrada(string pathSaida, string nomeArquivo);
        Task MoveArquivoSaida(string pathSaida, string nomeArquivo);
        Task MoveArquivoErro(string pathSaida, string nomeArquivo);
    }
}
