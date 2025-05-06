using System.ComponentModel.DataAnnotations;

namespace StreamingAPI.DTO
{
    public class UsuarioPostDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string Senha { get; set; }
    }
}
