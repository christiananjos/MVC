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
            foreach (var item in linhasCNAB)
            {

            }

            throw new NotImplementedException();
        }
    }
}
