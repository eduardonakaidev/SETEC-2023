﻿using Google.Protobuf;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Repositories;
using Mensagens.Modules.V1.Mensagens.Repositories.Interfaces;

namespace Mensagens.Data;
public static class Servicos
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMensagem, MensagemRepository>();

        return services;
    }

    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddTransient<MensagemCommand>();
        services.AddTransient<UsuarioCommand>();
        services.AddTransient<AcaoCommand>();
        services.AddTransient<MessagemPadraoCommand>();
        services.AddTransient<SessaoChatCommand>();
        

        return services;
    }
}
