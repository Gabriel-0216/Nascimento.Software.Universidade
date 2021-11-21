using System.ComponentModel.DataAnnotations;

namespace Nascimento.Software.Universidade.Api.DTO.Identity
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
