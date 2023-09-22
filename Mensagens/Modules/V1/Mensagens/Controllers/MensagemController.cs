using Mensagens.Data;
using Mensagens.Migrations;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Enums;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Data;

namespace Mensagens.Modules.V1.Mensagens.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MensagemController : ControllerBase
{
    private readonly MensagemCommand _mensagemCommand;
    private readonly DataContext _datacontext;

    public MensagemController(MensagemCommand mensagemCommand,DataContext dataContext)
    {
        _mensagemCommand = mensagemCommand;
        _datacontext = dataContext;
    }

    [HttpPost("primeiraMensagem/{id}")]
    public async Task<ActionResult<Mensagem>> EnviarPrimeiraMensagemAsync([FromBody] Mensagem enviarMensagem)
    {
        Response response = await _mensagemCommand.EnviarPrimeiraMensagemAsync(enviarMensagem);

        if (response.Falha)
        {
            return BadRequest(response.Status);
        }
        else
        {
            return Ok(response.Data ?? response.Status);
        }
    }
    [HttpGet]
    public async Task<ActionResult> BuscarMensagens()
    {   
        return Ok(await _datacontext.Mensagem.Include(x => x.UsuarioAbertura).Include(x => x.UsuarioRecebido).ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult> Post(SalvarMensagem enviarmensagem)
    {
        Mensagem mensagem = new (0, enviarmensagem.UsuarioEnvio,enviarmensagem.UsuarioRecebido,
            enviarmensagem.IdSessaoChat,null,(long)enviarmensagem.Acoes,enviarmensagem.Texto, enviarmensagem.DataHora,enviarmensagem.StatusMensagem);
        SessaoChat? sessao = await _datacontext.SessaoChat.FindAsync(mensagem.IdSessaoChat);
        Models.Usuario? usuarioEnvia = await _datacontext.Usuario.FindAsync(mensagem.IdUsuarioEnvio);
        Models.Usuario? usuarioRecebe = await _datacontext.Usuario.FindAsync(mensagem.IdUsuarioRecebido);
        if(mensagem.Texto is null)
        {
            return BadRequest("A mensagem não pode estar vazia");
        }
        if (usuarioRecebe is null)
        {
            return BadRequest("Usuario que recebe a mensagem não existe");
        }
        if(usuarioEnvia is null)
        {
            return BadRequest("Usuario que enviou a mensagem não existe");

        }
        

        if(sessao is null)
        {
            return BadRequest("Sessao nao encontrada");   
        }
        sessao.UltimaAtividade = mensagem.DataHora;
        _datacontext.Mensagem.Add (mensagem);
        await _datacontext.SaveChangesAsync();
        return Ok(mensagem);
    
    }
    [HttpGet("Mensagem{id}")]
    public async Task<ActionResult> GetMensagemId(long id)
    {
        Mensagem? Mensagem = await _datacontext
             .Mensagem.FindAsync(id);

        if (Mensagem is null)
        {
            return BadRequest("Id da mensagem não foi encontrado");
        }
        return Ok(Mensagem);
    }


}
