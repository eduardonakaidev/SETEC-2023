using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Mensagens.Modules.V1.Mensagens.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MensagemController : ControllerBase
{
    private readonly MensagemCommand _mensagemCommand;

    public MensagemController(MensagemCommand mensagemCommand)
    {
        _mensagemCommand = mensagemCommand;
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
}
