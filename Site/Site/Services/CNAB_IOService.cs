using Site.Services.Interfaces;

namespace Site.Services
{
    public class CNAB_IOService : ICNAB_IOService
    {
        private readonly string pathEntrada;
        private readonly string pathSaida;
        private readonly string pathErro;

        public CNAB_IOService()
        {
            pathEntrada = @"..\CNAB\Entrada\";
            pathSaida = @"..\CNAB\Saida\";
            pathErro = @"..\CNAB\Erro\";
        }

        public void CriaDiretoriosPrincipais()
        {
            var uniqueFilePath = Path.Combine(@"C:\CNAB\");

            if (!Directory.Exists(uniqueFilePath))
            {
                // Try to create the directory.
                DirectoryInfo entrada = Directory.CreateDirectory(pathEntrada);
                DirectoryInfo saida = Directory.CreateDirectory(pathSaida);
                DirectoryInfo erro = Directory.CreateDirectory(pathErro);
            }
        }

        public void UploadEntrada(IFormFile file, string nomeArquivo)
        {
            using (var stream = File.Create(string.Concat(pathEntrada, nomeArquivo)))
            {
                file.CopyToAsync(stream);
            }
        }

        public void MoveArquivoErro(IFormFile file, string nomeArquivo)
        {
            using (var stream = File.Create(string.Concat(pathErro, nomeArquivo)))
            {
                file.CopyToAsync(stream);
            }

            var arquivoEntradaPath = string.Concat(pathEntrada, nomeArquivo);

            File.Delete(arquivoEntradaPath);
        }

        public void MoveArquivoSaida(IFormFile file, string nomeArquivo)
        {
            using (var stream = File.Create(string.Concat(pathSaida, nomeArquivo)))
            {
                file.CopyToAsync(stream);

            }

            var arquivoEntradaPath = string.Concat(pathEntrada, nomeArquivo);

            File.Delete(arquivoEntradaPath);

        }


    }
}
