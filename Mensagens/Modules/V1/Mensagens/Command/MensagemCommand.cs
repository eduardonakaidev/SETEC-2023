using AutoMapper;
using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Mensagens.Modules.V1.Mensagens.Models.Request;
using Mensagens.Modules.V1.Mensagens.Repositories.Interfaces;

namespace Mensagens.Modules.V1.Mensagens.Command;

public class MensagemCommand
{
    private readonly IMapper _mapper;
    private readonly IMensagem _mensagemRepository;

    public MensagemCommand(IMapper mapper, IMensagem mensagemRepository)
    {
        _mapper = mapper;
        _mensagemRepository = mensagemRepository;
    }

    public async Task<Response> EnviarPrimeiraMensagemAsync(Mensagem enviarMensagem)
    {
        Mensagem mensagemSalva = await _mensagemRepository.
            SalvarMensagemAsync(enviarMensagem);

        return new Response(true, mensagemSalva, "Mensagem enviada com sucesso!");
    }
}
