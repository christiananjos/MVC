using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CNABController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Transacao>> UploadCNAB()
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            
            
            throw new NotImplementedException();

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetAllTransacoes()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transacao>> GetById(Guid id)
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
