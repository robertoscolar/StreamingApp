using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StreamingAPI.Model
{
    [Table("criador")]
    public class Criador
    {
        [Key]
        public int Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [JsonIgnore]
        public List<Conteudo> Conteudos { get; set; }
    }
}
