using System.ComponentModel.DataAnnotations;

namespace StreamingAPI.DTO
{
    public class AuthDTO
    {
        [Required(ErrorMessage = "O e-mail é obrigatório. Por favor, forneça e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória. Por favor, forneça uma senha.")]
        public string Senha { get; set; }
    }
}
