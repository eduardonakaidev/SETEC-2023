using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Models.Request;
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
        
        private readonly MessagemPadraoCommand _mesagemPadraoCommand;
        public MensagemPadraoController(DataContext dataContext, MessagemPadraoCommand mensagemPadraoCommand)
        {
            _dataContext = dataContext;
            _mesagemPadraoCommand = mensagemPadraoCommand;
           
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _mesagemPadraoCommand.RetornarTodos());
        }

        [HttpPost]
        public async Task<ActionResult> Post(CriarMensagemPadraoDto criarmensagemPadrao)
        {
            MensagemPadrao? mensagempadrao = new(0, criarmensagemPadrao.Texto, criarmensagemPadrao.IndiceArvore, criarmensagemPadrao.ProximoIndice, criarmensagemPadrao.IndiceAnterior);
            
            _dataContext.MensagemPadrao.Add(mensagempadrao);
            await _dataContext.SaveChangesAsync();
            return Ok(mensagempadrao);
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
        [HttpGet("MensagemPadrao{id}")]
        public async Task<ActionResult> GetMensagemPadraoId(long id)
        {
            MensagemPadrao? MensagemPadrao = await _dataContext
                 .MensagemPadrao.FindAsync(id);

            if (MensagemPadrao is null)
            {
                return BadRequest("Id da mensagem padrao não foi encontrado");
            }
            return Ok(MensagemPadrao);
        }


    }
}

