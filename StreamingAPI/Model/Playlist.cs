using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingAPI.Model
{
    [Table("playlist")]
    public class Playlist
    {
        [Key]
        public int Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [ForeignKey("Usuario")]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [Column("data_inclusao")]
        public DateTime? dataInclusao { get; set; }

        [Column("data_atualizacao")]
        public DateTime? dataAtualizacao { get; set; }

        public List<Conteudo>? Conteudos;
    }
}
