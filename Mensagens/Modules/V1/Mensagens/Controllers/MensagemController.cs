using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Enums;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
   
  
}
