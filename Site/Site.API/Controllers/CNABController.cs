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

        [HttpPost]
        public async Task<ActionResult> UploadCNAB(IFormFile file)
        {
            if (file.Length <= 0)
                return BadRequest("Arquivo Vazio. Insira um arquivo com conteudo CNAB .txt");

            if (Path.GetExtension(file.FileName) != ".txt")
                return BadRequest("Arquivo invalido. Insira um arquivo com conteudo CNAB .txt");

            string pathEntrada = @"..\CNAB\Entrada\";
            string pathSaida = @"..\CNAB\Saida\";
            string pathErro = @"..\CNAB\Erro\";

            var uniqueFilePath = Path.Combine(@"C:\CNAB\");

            if (!Directory.Exists(uniqueFilePath))
            {
                // Try to create the directory.
                DirectoryInfo entrada = Directory.CreateDirectory(pathEntrada);
                DirectoryInfo saida = Directory.CreateDirectory(pathSaida);
                DirectoryInfo erro = Directory.CreateDirectory(pathErro);
            }

            //Save the file to disk
            using (var stream = System.IO.File.Create(string.Concat(pathEntrada, file.FileName)))
            {
                await file.CopyToAsync(stream);
            }

            //_clienteService.Add

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
