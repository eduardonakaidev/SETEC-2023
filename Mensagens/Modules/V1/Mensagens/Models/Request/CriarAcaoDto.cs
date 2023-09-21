using Mensagens.Modules.V1.Mensagens.Enums;

namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class CriarAcaoDto
    {
        public CriarAcaoDto(string? conteudo, TipoAcao tipoAcao)
        {
            Conteudo = conteudo;
            TipoAcao = tipoAcao;
        }

        public string? Conteudo {  get; set; }
        public TipoAcao TipoAcao { get; set; }
    }
}
