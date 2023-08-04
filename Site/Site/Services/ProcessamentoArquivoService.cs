using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class ProcessamentoArquivoService : IProcessamentoArquivoService
    {
        private readonly ICNAB_IOService _IOService;

        public ProcessamentoArquivoService(ICNAB_IOService iOService)
        {
            _IOService = iOService;
        }

        public async Task<Dictionary<bool, string>> ProcessaArquivoPorCNABId(string nomeArquivo)
        {
            //Pegar o arquivo da pasta Entrada
            //Ler o conteudo
            var conteudo = await _IOService.LeCNABEntradaPorNomeArquivo(nomeArquivo);

            //Validar estrutura
            var retornoValidacao = await ValidaArquivo(conteudo);



            //Salvar as transações no banco
            //Atualizar o historico de CNAB com o mesmo ID : Se sucesso > Enum Processado, Se Erro > Enum Erro

            throw new NotImplementedException();
        }

        public async Task<Dictionary<bool, string>> ValidaArquivo(IEnumerable<string> linhasCNAB)
        {
            int linhaValidada = 1;
            string msgErro = "Erro Linha " + linhaValidada;
            var validacao = new Dictionary<bool, string>();


            foreach (var linha in linhasCNAB)
            {
                //Tamanho da linha = 80
                var tamanho = linha.Length;

                if (linha.Length == 80)
                    validacao.Add(false, string.Concat(msgErro, " Tamanho de caracters invalido no arquivo"));

                //0 até 34 tem que ser somente numeros

                //1º Posicao tem que ser de 1 a 9
                //1 a 8 Data Valida
                //19 a 29 > CPF valido
            }


            throw new NotImplementedException();
        }
    }
}
