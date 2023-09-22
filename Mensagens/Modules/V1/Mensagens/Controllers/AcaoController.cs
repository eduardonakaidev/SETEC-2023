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
    public class AcaoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly AcaoCommand _acaoCommand;

        public AcaoController(DataContext dataContext, AcaoCommand acaoCommand)
        {
            _dataContext = dataContext;
            _acaoCommand = acaoCommand;
        }

        [HttpGet("Buscar ações")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _acaoCommand.RetornarTodos());
        }

        [HttpPost]
        public async Task<ActionResult> Post(CriarAcaoDto Criaracao)
        {
            Acao? acao = new(0, Criaracao.Conteudo, Criaracao.TipoAcao);
            _dataContext.Acao.Add(acao);
            await _dataContext.SaveChangesAsync();
            return Ok(acao);
        }

        [HttpDelete("acao/{id}")]
        public async Task<ActionResult> Deletar(long id)
        {
            Acao? Acao = await _dataContext
                .Acao.FindAsync(id);

            if (Acao is null)
            {
                return BadRequest("Id da Ação não foi encontrado");
            }
            _dataContext.Acao.Remove(Acao);
            await _dataContext.SaveChangesAsync();

            return Ok("Deletado com sucesso!");
        }

[HttpGet("Acao{id}")]
    public async Task<ActionResult> GetAcaoId(long id)
    {
        Acao? Acao = await _dataContext
             .Acao.FindAsync(id);

        if (Acao is null)
        {
            return BadRequest("Id da ação não foi encontrado");
        }
        return Ok(Acao);
    }
        
    }
    
}

