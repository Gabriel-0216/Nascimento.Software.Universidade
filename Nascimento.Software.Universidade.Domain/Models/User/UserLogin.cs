using System.ComponentModel.DataAnnotations;

namespace Nascimento.Software.Universidade.Domain.Models.User
{
    public class UserLogin
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
