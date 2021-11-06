using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;
using System;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICommomService<Course> _service;
        public CoursesController(ICommomService<Course> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Course entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _service.Add(entity));

                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return BadRequest("não foi possível salvar o registro");
        }

    }
}
