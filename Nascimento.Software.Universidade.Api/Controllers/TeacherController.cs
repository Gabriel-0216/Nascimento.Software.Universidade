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
        [Route("listarTodos")]
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
        [Route("adicionar")]
        public async Task<ActionResult> Post(Teacher entity)
        {
            try
            {
                if(await _services.Add(entity))
                {
                    return Ok("Adicionado");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return BadRequest("Não foi possível deletar");
        }

        [HttpDelete]
        [Route("deletar")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if(await _services.Delete(id))
                {
                    return Ok("Deletado");
                }      
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return BadRequest("Não foi possível deletar o professor.");
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(Teacher entity)
        {
            try
            {
                var entityGet = await _services.Get(entity.Id);
                if (entityGet != null)
                {
                    if (await _services.Update(entity))
                    {
                        return Ok("Atualizado");
                    }
                }

            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return BadRequest("Não foi possível atualizar");
        }
    }
}
