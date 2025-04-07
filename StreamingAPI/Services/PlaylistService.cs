using StreamingAPI.Repositories.Impl;

namespace StreamingAPI.Services
{
    public class PlaylistService
    {
        private readonly PlaylistService _playlistService;

        public PlaylistService(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }
    }
}