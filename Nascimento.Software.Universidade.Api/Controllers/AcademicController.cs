using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Universidade.Api.DTO;
using Nascimento.Software.Universidade.Application.Services.AcademicRegistration;
using Nascimento.Software.Universidade.Domain.Models.University.StudentCourseRegister;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicController : ControllerBase
    {
        private readonly IAcademicService _service;
        private readonly IMapper _mapper;
        public AcademicController(IAcademicService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var entity = await _service.Get();
            if (entity != null)
            {
                return Ok(entity);
            }

            return BadRequest("Deu ruim");
        }

        [HttpPost]
        public async Task<ActionResult> Post(AcademicRegisterDTO studentDTO)
        {
            var studentCourse = _mapper.Map<StudentCourse>(studentDTO);
            if (ModelState.IsValid)
            {
                if (await _service.Start(studentCourse))
                {
                    return Ok("cadastrado");
                }
            }

            return BadRequest("Ocorreu um erro");
        }
    }
}
