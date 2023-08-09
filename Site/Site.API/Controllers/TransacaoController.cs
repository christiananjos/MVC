using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetAll()
        {
            var transacoes = await _transacaoService.GetAll();
            return Ok(transacoes);
        }

        [HttpGet("{nomeLoja}")]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetByNomeLoja(string nomeLoja)
        {
            var transacoes = await _transacaoService.GetTransacoesByNomeLoja(nomeLoja);
            return Ok(transacoes);
        }

        [HttpGet("extrato/{nomeLoja}")]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetExtratoByNomeLoja(string nomeLoja)
        {
            var transacoes = await _transacaoService.CalculaTransacoes(nomeLoja);

            return Ok(transacoes);
        }
    }
}
