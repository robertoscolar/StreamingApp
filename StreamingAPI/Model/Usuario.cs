using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StreamingAPI.Model
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Column("nome")]
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string? Nome { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "O campo email é obrigatório.")]
        public string? Email { get; set; }

        [Column("senha")]
        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string? Senha { get; set; }

        public List<Playlist>? Playlists;
    }
}
