namespace Mensagens.Modules.V1.Mensagens.Models.Request
{
    public class CriarMensagemPadraoDto
    {
        public CriarMensagemPadraoDto(string? texto, int indiceArvore, int proximoIndice, int indiceAnterior)
        {
            Texto = texto;
            IndiceArvore = indiceArvore;
            ProximoIndice = proximoIndice;
            IndiceAnterior = indiceAnterior;
        }

        public string? Texto { get; set; }

        public int IndiceArvore { get; set; }
        public int ProximoIndice { get; set; }

        public int IndiceAnterior { get; set; }

    }
}
