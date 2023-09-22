using Mensagens.Modules.V1.Mensagens.Enums;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class IniciarSessaoDto
    {
        public IniciarSessaoDto(DateTime abertura, DateTime ultimaAtividade, StatusSessaoChat status, long usuarioAbertura, long usuarioRecebimento)
        {
            Abertura = DateTime.Now;
            UltimaAtividade = ultimaAtividade;
            Status = status;
            UsuarioAbertura = usuarioAbertura;
            UsuarioRecebimento = usuarioRecebimento;
        }

        public DateTime Abertura{ get; set; }
        public DateTime UltimaAtividade { get;set;}
        public StatusSessaoChat Status { get;set;}
        public long  UsuarioAbertura {  get;set;}
        public long UsuarioRecebimento { get;set;}

    }
}
