using System.ComponentModel.DataAnnotations;

namespace StreamingAPI.Model
{
    public class Playlist
    {
        [Key]
        public int ID { get; set; }

        public string? Name { get; set; }

        public User? User { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<Content>? Contents;
    }
}
