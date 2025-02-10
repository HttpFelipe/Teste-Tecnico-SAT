using System.ComponentModel.DataAnnotations;

namespace LoginAppAPI.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public Usuario(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }
    }
}