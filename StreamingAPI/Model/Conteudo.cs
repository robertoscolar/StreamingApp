using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StreamingAPI.Model
{
    [Table("conteudo")]
    public class Conteudo
    {
        [Key]
        public int Id { get; set; }

        [Column("titulo")]
        public string? Titulo { get; set; }

        [Column("tipo")]
        public string? Tipo { get; set; }

        [ForeignKey("Criador")]
        [Column("criador_id")]
        [JsonIgnore]
        public int CriadorId { get; set; }
        public Criador? Criador { get; set; }
    }
}
