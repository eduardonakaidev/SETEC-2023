using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;

namespace Mensagens.Modules.V1.Mensagens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemPadraoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public MensagemPadraoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _dataContext
                .MensagemPadrao.Where(x => x.Id > 0)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(MensagemPadrao mensagemPadrao)
        {
            
            _dataContext.MensagemPadrao.Add(mensagemPadrao);
            await _dataContext.SaveChangesAsync();
            return Ok(mensagemPadrao);
        }

        [HttpDelete("mensagemPadrao/{id}")]
        public async Task<ActionResult> Deletar(long id)
        {
            MensagemPadrao? MensagemPadrao = await _dataContext
                .MensagemPadrao.FindAsync(id);

            if (MensagemPadrao is null)
            {
                return BadRequest("Id não foi encontrado");
            }
            _dataContext.MensagemPadrao.Remove(MensagemPadrao);
            await _dataContext.SaveChangesAsync();

            return Ok("Deletado com sucesso!");
        }

        
    }
}

