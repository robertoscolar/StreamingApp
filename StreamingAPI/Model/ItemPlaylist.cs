using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StreamingAPI.Model
{
    [Table("item_playlist")]
    public class ItemPlaylist
    {
        [ForeignKey("Playlist")]
        [Column("playlist_id")]
        [JsonIgnore]
        public int PlaylistId { get; set; }

        [JsonIgnore]
        public Playlist? Playlist { get; set; }

        [ForeignKey("Conteudo")]
        [Column("conteudo_id")]
        [JsonIgnore]
        public int ConteudoId { get; set; }
        public Conteudo? Conteudo { get; set; }
    }
}
