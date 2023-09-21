using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
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

        public SessaoChatController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _dataContext
                .SessaoChat.Where(x => x.IdSessaoChat > 0)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(SessaoChat SessaoChat)
        {
            Usuario? usuarioabertura = await _dataContext.Usuario.FindAsync(SessaoChat.IdUsuarioAbertura);
            if(usuarioabertura is null){
                return BadRequest("Id do usuário abertura não foi encontrado");
            }
            Usuario? usuariorecebimento = await _dataContext.Usuario.FindAsync(SessaoChat.IdUsuarioRecebido);
            if (usuariorecebimento is null){

                return BadRequest("Id do usuário recebimento não foi encontrado");
            }
            _dataContext.SessaoChat.Add(SessaoChat);
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

        
    }
}

