using Microsoft.AspNetCore.Mvc;
using StreamingAPI.Repositories.Impl;
using StreamingAPI.Services;

namespace StreamingAPI.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {

        private readonly UserRepository _userRepository;

        public AuthController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> AuthenticateAsync(string email, string password) 
        {
            var user = _userRepository.GetByEmailAndPassword(email, password);

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
