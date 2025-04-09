using StreamingAPI.DTO;
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

        public Playlist AdicionarPlaylist(PlaylistCadastroDTO playlistDTO)
        {

            var novaPlaylist = new Playlist
            {
                Nome = playlistDTO.Nome,
                UsuarioId = playlistDTO.UsuarioId,
                DataInclusao = DateTime.Now
            };

            foreach (var conteudoId in playlistDTO.ConteudoIds)
            {
                var itemPlaylist = new ItemPlaylist
                {
                    Playlist = novaPlaylist,
                    ConteudoId = conteudoId
                };

                novaPlaylist.ItensPlaylist.Add(itemPlaylist);
            }

            _playlistRepository.Add(novaPlaylist);
            return novaPlaylist;
        }

        public Playlist AtualizarPlaylist(PlaylistCadastroDTO novasInformacoesDTO, Playlist playlistExistente)
        {
            playlistExistente.Nome = novasInformacoesDTO.Nome;
            playlistExistente.UsuarioId = novasInformacoesDTO.UsuarioId;
            playlistExistente.DataAtualizacao = DateTime.Now;

            var conteudoIdsExistentes = playlistExistente.ItensPlaylist.Select(ip => ip.ConteudoId).ToList();
            var conteudosParaRemover = conteudoIdsExistentes.Except(novasInformacoesDTO.ConteudoIds).ToList();

            foreach (var conteudoId in conteudosParaRemover)
            {
                var itemParaRemover = playlistExistente.ItensPlaylist.FirstOrDefault(ip => ip.ConteudoId == conteudoId);
                if (itemParaRemover != null)
                {
                    playlistExistente.ItensPlaylist.Remove(itemParaRemover);
                }
            }

            var novosConteudosParaAdicionar = novasInformacoesDTO.ConteudoIds.Except(conteudoIdsExistentes).ToList();
            foreach (var conteudoId in novosConteudosParaAdicionar)
            {
                var novoItem = new ItemPlaylist
                {
                    Playlist = playlistExistente,
                    ConteudoId = conteudoId
                };
                playlistExistente.ItensPlaylist.Add(novoItem);
            }

            _playlistRepository.Update(playlistExistente);
            return playlistExistente;
        }

        public void DeletarPlaylist(int id)
        {
            _playlistRepository.Delete(id);
        }
    }
}