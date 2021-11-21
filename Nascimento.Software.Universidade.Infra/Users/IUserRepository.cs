using Microsoft.AspNetCore.Identity;
using Nascimento.Software.Universidade.Domain.Models.User;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Infra.Users
{
    public interface IUserRepository
    {
        Task<IdentityUser> Login(UserLogin user);
        Task<IdentityUser> Register(UserRegistration user);
    }
}
