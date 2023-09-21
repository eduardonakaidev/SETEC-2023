using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Command
{
    public class SessaoChatCommand
    {
        private readonly DataContext _dataContext;
        public SessaoChatCommand(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Response> RetornarTodos()
        {
            List<SessaoChat> sessaoChat = await _dataContext.SessaoChat.ToListAsync();
            return new Data.Response(true, sessaoChat, "Sessões buscados com sucesso");
        }
    }
}
