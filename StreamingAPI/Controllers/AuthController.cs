using Microsoft.AspNetCore.Mvc;
using StreamingAPI.DTO;
using StreamingAPI.Services;

namespace StreamingAPI.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {

        private readonly UsuarioService _usuarioService;

        public AuthController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] AuthDTO authDTO)
        {
            string token = _usuarioService.Autenticar(authDTO);

            if (token == null)
            {   
                return Unauthorized(new
                {
                    code = 0,
                    message = "Usuário ou senha incorretos.",
                    token = ""
                });
            }

            return new
            {
                code = 1,
                message = "Acesso liberado",
                token = token
            };
        }
    }
}
