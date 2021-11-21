using Microsoft.AspNetCore.Identity;
using Nascimento.Software.Universidade.Domain.Models.User;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Infra.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityUser> Login(UserLogin user)
        {
            var userExists = await _userManager.FindByEmailAsync(user.Email);
            if (userExists == null) return null;

            var valid = await _userManager.CheckPasswordAsync(userExists, user.Password);
            if (!valid) return null;

            return userExists;
        }

        public async Task<IdentityUser> Register(UserRegistration user)
        {
            var userIdentity = new IdentityUser()
            {
                Email = user.Email,
                UserName = user.Name,
            };

            var isCreated = await _userManager.CreateAsync(userIdentity, user.Password);
            if (isCreated.Succeeded)
            {
                return await _userManager.FindByEmailAsync(userIdentity.Email);
            }
            return null;
        }
    }
}
