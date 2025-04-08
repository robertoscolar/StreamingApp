using StreamingAPI.Model;
using StreamingAPI.Repositories.Impl;

namespace StreamingAPI.Services
{
    public class PlaylistService
    {
        private readonly PlaylistRepository _playlistRepository;

        public PlaylistService(PlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public List<Playlist> BuscarTodos()
        {
            return _playlistRepository.GetAll();
        }

        public Playlist BuscarPorId(int id)
        {
            return _playlistRepository.GetByID(id);
        }

        public void AdicionarPlaylist(Playlist playlist)
        {

        }

        public void AtualizarPlaylist(Playlist playlist)
        {

        }

        public void DeletarPlaylist(Playlist playlist)
        {

        }
    }
}