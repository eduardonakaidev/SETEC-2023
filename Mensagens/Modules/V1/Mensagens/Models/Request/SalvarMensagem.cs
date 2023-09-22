using Mensagens.Modules.V1.Mensagens.Enums;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class SalvarMensagem
    {
        public SalvarMensagem()
        {
        }

        public long UsuarioEnvio { get; set; }
        public long UsuarioRecebido { get; set; }
        public long IdSessaoChat { get; set; }
        public long Acoes { get; set; }
        public string? Texto { get; set; }
        public DateTime DataHora { get; set; }

        public StatusMensagem StatusMensagem { get; set; }
        
    }
}
