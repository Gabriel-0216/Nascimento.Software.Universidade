using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.Person.Teacher;
using System;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ICommomService<Teacher> _services;
        public TeacherController(ICommomService<Teacher> services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _services.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Teacher entity)
        {
            try
            {
                await _services.Add(entity);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
