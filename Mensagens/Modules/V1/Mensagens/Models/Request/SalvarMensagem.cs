using Mensagens.Modules.V1.Mensagens.Enums;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class SalvarMensagem
    {
        public SalvarMensagem(long usuarioEnvio, long usuarioRecebido, long sessaoChat, TipoAcao acoes, string? texto, StatusMensagem statusMensagem)
        {
            UsuarioEnvio = usuarioEnvio;
            UsuarioRecebido = usuarioRecebido;
            IdSessaoChat = sessaoChat;
            Acoes = acoes;
            Texto = texto;
            DataHora = DateTime.Now;
            StatusMensagem = statusMensagem;
        }

        public long UsuarioEnvio { get; set; }
        public long UsuarioRecebido { get; set; }
        public long IdSessaoChat { get; set; }
        public TipoAcao Acoes { get; set; }
        public string? Texto { get; set; }
        public DateTime DataHora { get; set; }

        public StatusMensagem StatusMensagem { get; set; }
        
    }
}
