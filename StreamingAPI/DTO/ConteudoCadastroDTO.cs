using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingAPI.DTO
{
    public class ConteudoCadastroDTO
    {
        
        [Required(ErrorMessage = "O campo titulo é obrigatório.")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O campo tipo é obrigatório.")]
        public string? Tipo { get; set; }

        [Required(ErrorMessage = "O campo criadorId é obrigatório.")]
        public int CriadorId { get; set; }
    }
}
