using Site.Services.Interfaces;

namespace Site.Services
{
    public class CNAB_IOService : ICNAB_IOService
    {
        public Task MoveArquivoErro(string pathSaida, string nomeArquivo)
        {
            throw new NotImplementedException();
        }

        public Task MoveArquivoSaida(string pathSaida, string nomeArquivo)
        {
            throw new NotImplementedException();
        }

        public Task UploadEntrada(string pathSaida, string nomeArquivo)
        {
            throw new NotImplementedException();
        }
    }
}
