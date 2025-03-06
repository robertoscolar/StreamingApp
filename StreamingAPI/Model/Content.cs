using System.ComponentModel.DataAnnotations;

namespace StreamingAPI.Model
{
    public class Content
    {
        [Key]
        public int ID { get; set; }

        public string? Title { get; set; }

        public string? Type { get; set; }

        public Creator? Creator { get; set; }
    }
}
