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
    public class SessaoChatController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly SessaoChatCommand _sessaoChatCommand;
        public SessaoChatController(DataContext dataContext,SessaoChatCommand sessaoChatCommand)
        {
            _dataContext = dataContext;
            _sessaoChatCommand = sessaoChatCommand;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _sessaoChatCommand.RetornarTodos());
        }

        [HttpPost]
        public async Task<ActionResult> Post(IniciarSessaoDto SessaoChat)
        {
            SessaoChat? sessaochat = new(0, SessaoChat.UsuarioAbertura, SessaoChat.UsuarioRecebimento, SessaoChat.Abertura, SessaoChat.UltimaAtividade, SessaoChat.Status);
            Usuario? usuarioabertura = await _dataContext.Usuario.FindAsync(sessaochat.UsuarioAbertura);
            
            Usuario? usuariorecebimento = await _dataContext.Usuario.FindAsync(sessaochat.IdUsuarioRecebido);
            if (usuariorecebimento is null){

                return BadRequest("Id do usuário recebimento não foi encontrado");
            }
            _dataContext.SessaoChat.Add(sessaochat);
            await _dataContext.SaveChangesAsync();
            return Ok(SessaoChat);
        }

        [HttpDelete("sessaoChat/{id}")]
        public async Task<ActionResult> Deletar(long id)
        {
            SessaoChat? SessaoChat = await _dataContext
                .SessaoChat.FindAsync(id);

            if (SessaoChat is null)
            {
                return BadRequest("Id da Sessão não foi encontrado");
            }
            _dataContext.SessaoChat.Remove(SessaoChat);
            await _dataContext.SaveChangesAsync();

            return Ok("Deletado com sucesso!");
        }
        [HttpGet("sessaoChat{id}")]
        public async Task<ActionResult> GetSessaoChatId(long id)
        {
            SessaoChat? SessaoChat = await _dataContext
                 .SessaoChat.FindAsync(id);

            if (SessaoChat is null)
            {
                return BadRequest("Id da Sessão não foi encontrado");
            }
            return Ok(SessaoChat);
        }


    }
}

