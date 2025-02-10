using LoginAppAPI.Models;

namespace LoginAppAPI.DTOs
{
    public class UsuarioResponseModel
    {
        public bool Error { get; set; }
        public string Body { get; set; } = string.Empty;
        public List<Usuario>? Usuarios { get; set; } = [];
    }
}