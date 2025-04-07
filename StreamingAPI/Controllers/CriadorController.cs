using Microsoft.AspNetCore.Mvc;
using StreamingAPI.Model;
using StreamingAPI.Services;

namespace StreamingAPI.Controllers
{
    [ApiController]
    [Route("api/v1/criador")]
    public class CriadorController : ControllerBase
    {
        private readonly CriadorService _criadorService;

        public CriadorController(CriadorService criadorService)
        {
            _criadorService = criadorService;
        }

        
    }
}
