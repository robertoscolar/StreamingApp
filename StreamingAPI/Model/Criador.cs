using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingAPI.Model
{
    [Table("criador")]
    public class Criador
    {
        [Key]
        public int Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        public List<Conteudo> Conteudos { get; set; }
    }
}
