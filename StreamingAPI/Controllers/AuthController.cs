using Microsoft.AspNetCore.Mvc;
using StreamingAPI.Model;
using StreamingAPI.Repositories;
using StreamingAPI.Services;

namespace StreamingAPI.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model) 
        {
            var user = UserRepository.Get(model.Email, model.Password);

            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
