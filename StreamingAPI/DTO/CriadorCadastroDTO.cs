﻿using System.ComponentModel.DataAnnotations;

namespace StreamingAPI.DTO
{
    public class CriadorCadastroDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }
    }
}
