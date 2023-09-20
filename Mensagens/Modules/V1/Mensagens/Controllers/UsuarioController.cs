using Mensagens.Data;
using Mensagens.Modules.V1.Mensagens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Modules.V1.Mensagens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UsuarioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _dataContext
                .Usuario.Where(x => x.Id > 0)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Usuario usuario)
        {
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

        [HttpDelete("/{id}")]
        public async Task<ActionResult> Deletar(int id)
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

