using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services;
using Site.Services.Interfaces;

namespace Site.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IClienteService _clienteService;

        public EnderecoController(IEnderecoService enderecoService, IClienteService clienteService)
        {
            _enderecoService = enderecoService;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetAll()
        {
            var Enderecos = await _enderecoService.GetAll();
            return Ok(Enderecos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetById(Guid id)
        {
            var Endereco = await _enderecoService.GetById(id);
            return Ok(Endereco);
        }

        [HttpPost]
        public async Task<ActionResult<Endereco>> Create([FromBody] Endereco endereco)
        {
            var cliente = await _clienteService.GetById(endereco.ClienteId);

            if (cliente == null)
                return NotFound("ClienteId não encontrado");


            var enderecoCreated = await _enderecoService.Add(endereco);

            return Ok(enderecoCreated);
        }

        [HttpPut]
        public async Task<ActionResult<Endereco>> Update([FromBody] Endereco endereco)
        {
            var cliente = await _clienteService.GetById(endereco.ClienteId);

            if (cliente == null)
                return NotFound("ClienteId não encontrado");

            var enderecoUpdated = await _enderecoService.Update(endereco);

            return Ok(enderecoUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Endereco>> Delete(Guid id)
        {
            var endereco = await _enderecoService.GetById(id);

            if (endereco == null)
                return NotFound("Endereco não existe");

            if (endereco != null)
            {
                var enderecoDeleted = await _enderecoService.LogicalRemove(endereco);
                return Ok(enderecoDeleted);
            }

            return Ok();
        }

        [HttpGet("util/{cep}")]
        public async Task<ActionResult<Endereco>> GetEnderecoPorCEP(string cep)
        {
            var endereco = await _enderecoService.GetEnderecoPorCEP(cep);
            return Ok(endereco);
        }




    }
}
