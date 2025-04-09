using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamingAPI.DTO;
using StreamingAPI.Model;
using StreamingAPI.Services;

namespace StreamingAPI.Controllers
{
    [ApiController]
    [Route("api/v1/criador")]
    [Authorize]
    public class CriadorController : ControllerBase
    {
        private readonly CriadorService _criadorService;

        public CriadorController(CriadorService criadorService)
        {
            _criadorService = criadorService;
        }

        [HttpGet("buscar")]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            List<Criador> criadores = _criadorService.EncontrarTodos();
            return Ok(criadores);
        }

        [HttpGet("buscar/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<dynamic>> GetCriador(int id)
        {
            Criador criador = _criadorService.EncontrarCriadorPorId(id);

            if (criador == null)
            {
                return NotFound(new
                {
                    code = 0,
                    message = "Criador não encontrado",
                    token = ""
                });
            }

            return new
            {
                criador = criador
            };
        }


        [HttpPost("cadastrar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<dynamic>> CadastrarCriador([FromBody] CriadorCadastroDTO criador)
        {

            _criadorService.RegistrarCriador(criador);

            return new
            {
                resposta = "Criador cadastrado com sucesso."
            };
        }
    }
}
