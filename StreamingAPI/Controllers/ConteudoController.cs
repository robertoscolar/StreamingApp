using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StreamingAPI.DTO;
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

        [HttpGet("buscar")]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            List<Conteudo> conteudos = _conteudoService.EncontrarTodos();
            return Ok(conteudos);
        }

        [HttpGet("buscar/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [Authorize]
        public async Task<ActionResult<dynamic>> GetConteudo(int id)
        {
            Conteudo conteudo = _conteudoService.EncontrarConteudoPorId(id);

            if (conteudo == null)
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
                criador = conteudo
            };
        }


        [HttpPost("cadastrar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<dynamic>> CadastrarConteudo([FromBody] ConteudoCadastroDTO conteudoDTO)
        {

            bool resposta = _conteudoService.RegistrarConteudo(conteudoDTO);

            if (resposta) { 
                return new
                {
                    resposta = "Conteúdo cadastrado com sucesso."
                };

            } else
            {
                return new
                {
                    resposta = "Não foi possível inserir conteúdo. Criador não localizado na base."
                };
            }

            
        }
    }
}
