using System.ComponentModel.DataAnnotations;

namespace LoginAppAPI.DTOs
{
    public class UsuarioRequestModel
    {
        [Required]
        public string Login { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}