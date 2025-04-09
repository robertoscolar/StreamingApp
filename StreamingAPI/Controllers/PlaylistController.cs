using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamingAPI.DTO;
using StreamingAPI.Model;
using StreamingAPI.Services;

namespace StreamingAPI.Controllers
{
    [ApiController]
    [Route("api/v1/playlist")]
    [Authorize]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistService _playlistService;

        public PlaylistController(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarTodos()
        {
            var playlists = _playlistService.BuscarTodos();
            return Ok(playlists);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var playlist = _playlistService.BuscarPorId(id);

            if (playlist == null)
            {
                return NotFound();
            }

            return Ok(playlist);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var itemExistente = _playlistService.BuscarPorId(id);
            if (itemExistente == null)
            {
                return NotFound();
            }

            _playlistService.DeletarPlaylist(id);
            return NoContent();
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar(PlaylistCadastroDTO playlistDTO)
        {

            Playlist playlist = _playlistService.AdicionarPlaylist(playlistDTO);
            Playlist resultadoSalvo = _playlistService.BuscarPorId(playlist.Id);

            return Ok(resultadoSalvo);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] PlaylistCadastroDTO playlistNova)
        {
            Playlist playlistAntiga = _playlistService.BuscarPorId(id);

            if (playlistAntiga == null) 
            {
                return NotFound(new
                {
                    message = "Playlist não encontrada",
                });
            }

            Playlist resultado = _playlistService.AtualizarPlaylist(playlistNova, playlistAntiga);
            return Ok(resultado);
        }
    }
}
