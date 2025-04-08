using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamingAPI.DTO;
using StreamingAPI.Model;
using StreamingAPI.Services;

namespace StreamingAPI.Controllers
{
    [ApiController]
    [Route("api/v1/playlist")]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistService _playlistService;

        public PlaylistController(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet("buscar")]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<dynamic>> BuscarTodos()
        {
            
        }


        [HttpGet("buscar/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<dynamic>> BuscarPorId(int id)
        {

        }
    }
}
