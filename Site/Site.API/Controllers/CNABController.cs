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

        public CNABController(IHistoricoImportacaoCNABService historicoImportacaoCNABService, ICNAB_IOService iOService)
        {
            _historicoImportacaoCNABService = historicoImportacaoCNABService;
            _IOService = iOService;
        }

        [HttpPost]
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
                Status = EnumStatusCNAB.Importado


            };
            await _historicoImportacaoCNABService.Add(historico);

            //_IOService.MoveArquivoErro(file, file.FileName);
            _IOService.MoveArquivoSaida(file, file.FileName);

            return Ok("Arquivo salvo com sucesso. Use a lista de arquivos para Processar.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoImportacaoCNAB>> GetByCNABId(Guid id)
        {
            var historico = await _historicoImportacaoCNABService.GetById(id);

            return Ok(historico);
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAllCNABEntrada()
        {
            var historicos = await _historicoImportacaoCNABService.GetAll();

            return Ok(historicos);
        }
    }
}
