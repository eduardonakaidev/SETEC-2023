using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Mensagens.Modules.V1.Mensagens.Enums;

namespace Mensagens.Modules.V1.Mensagens.Models;

public class Acao
{
    public Acao(long id, string? conteudo, TipoAcao tipoAcao)
    {
        Id = id;
        Conteudo = conteudo;
        TipoAcao = tipoAcao;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string? Conteudo { get; set; }
    public TipoAcao TipoAcao { get; set; }
}
