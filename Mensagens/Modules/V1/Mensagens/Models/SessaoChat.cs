using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Mensagens.Modules.V1.Mensagens.Enums;

namespace Mensagens.Modules.V1.Mensagens.Models;


public class SessaoChat
   
{
    

    public SessaoChat(long idSessaoChat,
        long idUsuarioAbertura,
        long idUsuarioRecebido, 
        DateTime abertura ,
        DateTime ultimaAtividade, 
        StatusSessaoChat statusSessao 
      
        )
    {
        IdSessaoChat = idSessaoChat;
        IdUsuarioAbertura = idUsuarioAbertura;
        IdUsuarioRecebido = idUsuarioRecebido;
        Abertura = abertura;
        UltimaAtividade = ultimaAtividade;
        StatusSessao = statusSessao;
    
       
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long IdSessaoChat { get; set; }

    [ForeignKey("Usuario")]
    public long IdUsuarioAbertura { get; set; }

    [ForeignKey("Usuario")]
    public long IdUsuarioRecebido { get; set; }

    public DateTime Abertura { get; set; }

    public DateTime UltimaAtividade { get; set; }

    public StatusSessaoChat StatusSessao { get; set; }

   

    // Objetos que não fazem parte da entidade
    public Usuario? UsuarioAbertura { get; set; }

    public Usuario? UsuarioRecebido { get; set; }
}