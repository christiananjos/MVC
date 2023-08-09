using Microsoft.AspNetCore.Mvc;
using Site.Enums;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CNABController : ControllerBase
    {
        private readonly IHistoricoImportacaoCNABService _historicoImportacaoCNABService;
        private readonly ICNAB_IOService _IOService;
        private readonly IProcessamentoArquivoService _processamentoArquivo;

        public CNABController(IHistoricoImportacaoCNABService historicoImportacaoCNABService, ICNAB_IOService iOService, IProcessamentoArquivoService processamentoArquivo)
        {
            _historicoImportacaoCNABService = historicoImportacaoCNABService;
            _IOService = iOService;
            _processamentoArquivo = processamentoArquivo;
        }

        [HttpPost("UploadCNAB")]
        public async Task<ActionResult> UploadCNAB(IFormFile file)
        {
            if (file.Length <= 0)
                return BadRequest("Arquivo Vazio. Insira um arquivo com conteudo CNAB .txt");

            if (Path.GetExtension(file.FileName) != ".txt")
                return BadRequest("Arquivo invalido. Insira um arquivo com conteudo CNAB .txt");

            _IOService.CriaDiretoriosPrincipais();
            _IOService.UploadEntrada(file, file.FileName);

            var historico = new HistoricoImportacaoCNAB()
            {
                NomeArquivo = file.FileName,
                Usuario = "Usuario Teste",
                Status = EnumStatusCNAB.AguardandoProcessamento
            };

            await _historicoImportacaoCNABService.Add(historico);

            return Ok("Arquivo importado com sucesso.");
        }

        [HttpGet("ProcessaCNABPorId/{id}")]
        public async Task<ActionResult> ProcessaCNABPorId(Guid id)
        {
            var historico = await _historicoImportacaoCNABService.GetById(id);

            if (historico == null)
                return NotFound("CNAB não encontrado");

            var linhasCnab = await _IOService.LeCNABEntradaPorNomeArquivo(historico.NomeArquivo);

            var retornoValidacao = await _processamentoArquivo.ValidaArquivo(linhasCnab);

            if (!string.IsNullOrEmpty(retornoValidacao))
            {
                historico.Status = EnumStatusCNAB.Erro;
                historico.Mensagem = retornoValidacao;

                await _historicoImportacaoCNABService.Update(historico);


                _IOService.MoveArquivoErro(historico.NomeArquivo);

                return BadRequest(retornoValidacao);
            }


            var retornoProcessamento = await _processamentoArquivo.ProcessaArquivoCNAB(linhasCnab);

            if (!string.IsNullOrEmpty(retornoProcessamento))
            {
                historico.Status = EnumStatusCNAB.Erro;
                historico.Mensagem = retornoProcessamento;

                await _historicoImportacaoCNABService.Update(historico);


                _IOService.MoveArquivoErro(historico.NomeArquivo);

                return BadRequest(retornoProcessamento);
            }

            _IOService.MoveArquivoSaida(historico.NomeArquivo);

            historico.Status = EnumStatusCNAB.Processado;

            await _historicoImportacaoCNABService.Update(historico);

            return Ok("Processamento realizado com sucesso.");
        }

        [HttpGet("GetAllCNABEntrada")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllCNABEntrada()
        {
            var historicos = await _historicoImportacaoCNABService.GetAll();

            return Ok(historicos);
        }
    }
}
