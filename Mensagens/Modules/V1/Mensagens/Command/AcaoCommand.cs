using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Command
{
    public class AcaoCommand
    {
        private readonly DataContext _dataContext;
        public AcaoCommand(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Response> RetornarTodos()
        {
            List<Acao> acao = await _dataContext.Acao.ToListAsync();
            return new Data.Response(true, acao, "ações buscados com sucesso");
        }
    }
}
