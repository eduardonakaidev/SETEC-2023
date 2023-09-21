using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Command;
using Mensagens.Modules.V1.Mensagens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;

namespace Mensagens.Modules.V1.Mensagens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly UsuarioCommand _usuarioCommand;
       
        public UsuarioController(DataContext dataContext,UsuarioCommand usuarioCommand)
        {
            _dataContext = dataContext;
            _usuarioCommand = usuarioCommand;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok( await _usuarioCommand.RetornarTodos());
        }

        [HttpPost]
        public async Task<ActionResult> Post(SalvarUsuario salvarusuario)
        {
            Usuario usuario = new Usuario(0, salvarusuario.Nome, salvarusuario.Email);

            _dataContext.Usuario.Add(usuario);
            await _dataContext.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpGet("/{nome}")]
        public async Task<ActionResult> GetPeloNome(string nome)
        {
            return Ok(await _dataContext
                .Usuario.Where(x => x.Nome == nome)
                .ToListAsync());
        }

        [HttpDelete("usuario/{id}")]
        public async Task<ActionResult> Deletar(long id)
        {
            Usuario? usuario = await _dataContext
                .Usuario.FindAsync(id);

            if (usuario is null)
            {
                return BadRequest("Id do usuário não foi encontrado");
            }
            _dataContext.Usuario.Remove(usuario);
            await _dataContext.SaveChangesAsync();

            return Ok("Deletado com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult> EditarUsuario(Usuario editando)
        {
            Usuario? usuario = await _dataContext
                .Usuario.FindAsync(editando.Id);

            if (usuario is null)
            {
                return BadRequest("Id do usuário não foi encontrado");
            }

            usuario.Nome = editando.Nome;
            usuario.Email = editando.Email;

            await _dataContext.SaveChangesAsync();
            return Ok(usuario);

        }
    }
}

