using System.ComponentModel.DataAnnotations;

namespace Nascimento.Software.Universidade.Api.DTO.Identity
{
    public class UserRegisterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
