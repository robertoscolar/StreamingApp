using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [Column("criado_em")]
        public DateTime? DataInclusao { get; set; }

        [Column("atualizado_em")]
        public DateTime? DataAtualizacao { get; set; }

        public List<ItemPlaylist> ItensPlaylist { get; set; } = new List<ItemPlaylist>();
    }
}
