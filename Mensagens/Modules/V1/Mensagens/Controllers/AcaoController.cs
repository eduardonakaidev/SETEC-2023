using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Models;
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
        public async Task<ActionResult> Post(Acao Acao)
        {
            _dataContext.Acao.Add(Acao);
            await _dataContext.SaveChangesAsync();
            return Ok(Acao);
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

        
    }
}

