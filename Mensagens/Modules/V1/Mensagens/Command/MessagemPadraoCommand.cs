using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Command
{
    public class MessagemPadraoCommand
    {
        private readonly DataContext _dataContext;
        public MessagemPadraoCommand(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Response> RetornarTodos()
        {
            List<MensagemPadrao> mensagemPadrao = await _dataContext.MensagemPadrao.ToListAsync();
            return new Data.Response(true, mensagemPadrao, "mensagens padrão buscados com sucesso");
        }
    }
}
