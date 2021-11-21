using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Universidade.Api.DTO;
using Nascimento.Software.Universidade.Application.Services.AcademicRegistration;
using Nascimento.Software.Universidade.Domain.Models.University.Registration;
using Nascimento.Software.Universidade.Domain.Models.University.StudentCourseRegister;
using System;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AcademicController : ControllerBase
    {
        private readonly IAcademicService _service;
        private readonly ICourseDisciplineService _courseDiscipline;
        private readonly IMapper _mapper;
        public AcademicController(IAcademicService service,
            ICourseDisciplineService courseDisciplineService,
            IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
            _courseDiscipline = courseDisciplineService;
        }

        [HttpGet]
        [Route("listarTodos")]
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
        [Route("adicionarRegistroAcademico")]
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

        [HttpGet]
        [Route("GetAllDisciplinesCourse")]
        public async Task<ActionResult> GetAllDisciplinesCourse()
        {
            return Ok(await _courseDiscipline.GetAll());
        }

        [HttpGet]
        [Route("GetAllDisciplinesByCourse")]
        public async Task<ActionResult> GetDisciplinesByCourse(int CourseId)
        {
            var disciplines = await _courseDiscipline.GetDisciplinesByCourse(CourseId);
            if (disciplines == null)
            {
                return BadRequest();
            }
            return Ok(disciplines);
        }

        [HttpGet]
        [Route("GetAllCoursesByDiscipline")]
        public async Task<ActionResult> GetCoursesByDiscipline(int disciplineId)
        {
            var courses = await _courseDiscipline.GetCoursesByDiscipline(disciplineId);
            if (courses == null)
            {
                return BadRequest();
            }
            return Ok(courses);
        }

        [HttpPost]
        [Route("RegisterCourseDiscipline")]
        public async Task<ActionResult> RegisterCourseDiscipline(DisciplineCourseDTO disciplineCourseDTO)
        {
            try
            {
                var mapReturn = _mapper.Map<Course_Disciplines>(disciplineCourseDTO);
                if (await _courseDiscipline.Start(mapReturn))
                {
                    return Ok("Cadastrado");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return BadRequest("Nâo foi possível cadastrar");
        }


        [HttpDelete]
        [Route("deletarRegistroAcademico")]
        public async Task<ActionResult> Delete()
        {
            return Ok();
        }

        [HttpPut]
        [Route("atualizarRegistroAcademico")]
        public async Task<ActionResult> Update()
        {
            return Ok();
        }
    }
}
