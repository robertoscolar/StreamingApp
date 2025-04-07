using Microsoft.AspNetCore.Mvc;
using StreamingAPI.Model;
using StreamingAPI.Services;

namespace StreamingAPI.Controllers
{
    [ApiController]
    [Route("api/v1/conteudo")]
    public class ConteudoController : ControllerBase
    {
        private readonly ConteudoService _conteudoService;

        public ConteudoController(ConteudoService conteudoService)
        {
            _conteudoService = conteudoService;
        }

        
    }
}
