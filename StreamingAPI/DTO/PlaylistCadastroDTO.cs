using System.ComponentModel.DataAnnotations;

namespace StreamingAPI.DTO
{
    public class PlaylistCadastroDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo usuarioId é obrigatório.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "A Playlist deve ter pelo menos um conteúdo adicionado.")]
        public List<int> ConteudoIds { get; set; } = new List<int>();
    }
}
