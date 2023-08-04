using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CNABController : ControllerBase
    {
        private readonly IHistoricoImportacaoCNABService _clienteService;
        private readonly ICNAB_IOService _IOService;

        public CNABController(IHistoricoImportacaoCNABService clienteService, ICNAB_IOService iOService)
        {
            _clienteService = clienteService;
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
            //_IOService.MoveArquivoErro(file, file.FileName);
            _IOService.MoveArquivoSaida(file, file.FileName);

            return Ok("Arquivo salvo com sucesso. Use a lista de arquivos para Processar.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transacao>> GetByCNABId(Guid id)
        {
            throw new NotImplementedException();
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetAllCNABEntrada()
        {
            throw new NotImplementedException();
        }



        [HttpGet("{nomeLoja}")]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetByLoja(string nomeLoja)
        {
            throw new NotImplementedException();
        }






    }
}
