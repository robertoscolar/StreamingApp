using System.ComponentModel.DataAnnotations;

namespace StreamingAPI.Model
{
    public class Creator
    {
        [Key]
        public int ID { get; set; }

        public string? Name { get; set; }

        public List<Content>? Contents;
    }
}
