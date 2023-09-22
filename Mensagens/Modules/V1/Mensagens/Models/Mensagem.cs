﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Mensagens.Modules.V1.Mensagens.Enums;

namespace Mensagens.Modules.V1.Mensagens.Models;

public class Mensagem
{
    public Mensagem(long id,
        long idUsuarioEnvio,
        long idUsuarioRecebido,
        long idSessaoChat, 
        long? idMensagemPadrao, 
        long? idAcoes, 
        string? texto,
        DateTime dataHora, 
        StatusMensagem statusMensagem
       )
    {
        Id = id;
        IdUsuarioEnvio = idUsuarioEnvio;
        IdUsuarioRecebido = idUsuarioRecebido;
        IdSessaoChat = idSessaoChat;
        IdMensagemPadrao = idMensagemPadrao;
        IdAcoes = idAcoes;
        Texto = texto;
        DataHora = dataHora;
        StatusMensagem = statusMensagem;
        
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [ForeignKey("Usuario")]
    public long IdUsuarioEnvio { get; set; }

    [ForeignKey("Usuario")]
    public long IdUsuarioRecebido { get; set; }

    [ForeignKey("SessaoChat")]
    public long IdSessaoChat { get; set; }

    [ForeignKey("MensagemPadrao")]
    public long? IdMensagemPadrao { get; set; }

    [ForeignKey("Acoes")]
    public long? IdAcoes { get; set; }

    [MaxLength(800, ErrorMessage = "{0} deve ter no maximo {1} caractares.")]
    public string? Texto { get; set; }

    public DateTime DataHora { get; set; }

    public StatusMensagem StatusMensagem { get; set; }

    // Objetos que não fazem parte da entidade
    public Usuario? UsuarioAbertura { get; set; }

    public Usuario? UsuarioRecebido { get; set; }

    public SessaoChat? Sessao { get; set; }

    public MensagemPadrao? MensagemPadrao { get; set; }

    public Acao? Acoes { get; set; }
}