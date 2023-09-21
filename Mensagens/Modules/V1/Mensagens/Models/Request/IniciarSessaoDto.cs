using Mensagens.Modules.V1.Mensagens.Enums;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class IniciarSessaoDto
    {
        public IniciarSessaoDto(DateTime abertura, DateTime ultimaAtividade, StatusSessaoChat status, int usuarioAbertura, int usuarioRecebimento)
        {
            Abertura = abertura;
            UltimaAtividade = ultimaAtividade;
            Status = status;
            UsuarioAbertura = usuarioAbertura;
            UsuarioRecebimento = usuarioRecebimento;
        }

        public DateTime Abertura{ get; set; }
        public DateTime UltimaAtividade { get;set;}
        public StatusSessaoChat Status { get;set;}
        public int  UsuarioAbertura {  get;set;}
        public int UsuarioRecebimento { get;set;}

    }
}
