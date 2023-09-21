using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mensagens.Modules.V1.Mensagens.Models;

public class Acao
{
    public Acao(long id, string? conteudo, int tipoAcao)
    {
        Id = id;
        Conteudo = conteudo;
        TipoAcao = tipoAcao;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string? Conteudo { get; set; }
    public int TipoAcao { get; set; }
}
