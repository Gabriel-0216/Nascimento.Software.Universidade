using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ICommomService<Student> _service;
        public StudentController(ICommomService<Student> service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult> Add(Student model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Add(model);
                    return Ok("Adicionado com sucesso");
                }
                return BadRequest("Ocorreu um erro");
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var studentsList = await _service.GetAll();
                return Ok(studentsList);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
