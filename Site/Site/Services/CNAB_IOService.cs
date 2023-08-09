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

        public void MoveArquivoErro(string nomeArquivo)
        {
            try
            {
                File.Move(string.Concat(pathEntrada, nomeArquivo), string.Concat(pathErro, nomeArquivo));
                File.Delete(string.Concat(pathEntrada, nomeArquivo));
            }
            catch (Exception)
            {

                throw new Exception(string.Concat("Erro ao mover o arquivo", nomeArquivo, " para ", pathErro));
            }
           
        }

        public void MoveArquivoSaida(string nomeArquivo)
        {
            try
            {
                File.Move(string.Concat(pathEntrada, nomeArquivo), string.Concat(pathSaida, nomeArquivo));

                File.Delete(string.Concat(pathEntrada, nomeArquivo));
            }
            catch (Exception)
            {

                throw new Exception(string.Concat("Erro ao mover o arquivo", nomeArquivo, " para ", pathSaida));
            }


        }

        public async Task<IEnumerable<string>> LeCNABEntradaPorNomeArquivo(string nomeArquivo)
        {
            try
            {
                string[] txtConteudo = await File.ReadAllLinesAsync(string.Concat(pathEntrada, nomeArquivo));

                List<string> listItems = txtConteudo.ToList();
                return listItems;

            }
            catch (Exception ex)
            {

                throw new Exception(string.Concat("Erro ao tentar ler o arquivo: ", nomeArquivo, " no direrio ", pathEntrada));
            }

        }
    }
}
