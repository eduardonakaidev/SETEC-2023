
using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Command
{
    public class UsuarioCommand
    {
        private readonly DataContext _dataContext;
        public UsuarioCommand(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Response> RetornarTodos()
        {   
            List<Usuario> usuarios =await _dataContext.Usuario.ToListAsync();
            return new Data.Response(true, usuarios, "usuarios buscados com sucesso");
        }
    }
}
