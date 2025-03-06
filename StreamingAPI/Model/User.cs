using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingAPI.Model
{
    [Table("users")]
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Column("full_name")]
        public string? Name { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("password")]
        public string? Password { get; set; }

        [Column("role")]
        public string? Role { get; set; }

        public List<Playlist>? Playlists;
    }
}
