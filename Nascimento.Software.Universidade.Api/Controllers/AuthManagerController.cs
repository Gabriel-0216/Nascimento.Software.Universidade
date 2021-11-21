using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Universidade.Api.Configuration;
using Nascimento.Software.Universidade.Api.DTO.Identity;
using Nascimento.Software.Universidade.Api.Tokens;
using Nascimento.Software.Universidade.Domain.Models.User;
using Nascimento.Software.Universidade.Infra.Users;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagerController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly TokenGenerator _tokens;
        public AuthManagerController(IUserRepository repository,
            IMapper mapper,
            TokenGenerator tokens)
        {
            _tokens = tokens;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<ActionResult> Registration(UserRegisterDTO user)
        {
            if (ModelState.IsValid)
            {
                var userRegistration = _mapper.Map<UserRegistration>(user);
                var userCreated = await _repository.Register(userRegistration);
                if (userCreated == null)
                {
                    return BadRequest("Ocorreu um erro no registro");
                }

                var token = _tokens.GenerateJwtToken(userCreated);

                return Ok(new AuthResult()
                {
                    Success = true,
                    Token = token,
                });



            }
            return BadRequest(new ResponseDTO() { Success = false });
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginDTO user)
        {

            if (ModelState.IsValid)
            {
                var userLogin = _mapper.Map<UserLogin>(user);
                var userLoginTry = await _repository.Login(userLogin);

                if (userLoginTry == null)
                {
                    return BadRequest("Ocorreu um erro");
                }

                var token = _tokens.GenerateJwtToken(userLoginTry);
                return Ok(new AuthResult()
                {
                    Token = token,
                    Success = true,
                });
            }
            return BadRequest(new ResponseDTO() { Success = false });
        }

    }
}
