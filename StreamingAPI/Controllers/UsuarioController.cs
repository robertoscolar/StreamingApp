using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamingAPI.DTO;
using StreamingAPI.Model;
using StreamingAPI.Services;

namespace StreamingAPI.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("buscar")]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            List<Usuario> usuarios = _usuarioService.EncontrarTodos();
            return Ok(usuarios);
        }

        [HttpGet("buscar/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<dynamic>> GetUsuario(int id)
        {
            Usuario usuario = _usuarioService.EncontrarUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound(new
                {
                    code = 0,
                    message = "Usuário não encontrado",
                    token = ""
                });
            }

            usuario.Senha = "";

            return new
            {
                usuario = usuario
            };
        }


        [HttpPost("cadastrar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<dynamic>> CadastrarUsuario([FromBody] UsuarioPostDTO usuarioDTO)
        {
            _usuarioService.RegistrarUsuario(usuarioDTO);

            return new
            {
                resposta = "Usuário cadastrado com sucesso."
            };
        }
    }
}
