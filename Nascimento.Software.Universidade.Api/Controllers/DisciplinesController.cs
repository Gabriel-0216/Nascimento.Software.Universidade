using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.University.Disciplines;
using System;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesController : ControllerBase
    {
        private readonly ICommomService<Discipline> _service;
        public DisciplinesController(ICommomService<Discipline> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("listarTodos")]
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
        [Route("adicionar")]
        public async Task<ActionResult> Post(Discipline model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _service.Add(model))
                    {
                        return Ok("Cadastrado com sucesso");
                    }
                }
                return BadRequest("não foi possível adicionar");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("deletar")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var entity = await _service.Get(id);
                if(entity != null)
                {
                    if(await _service.Delete(id))
                    {
                        return Ok("deletado");
                    }
                }
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return BadRequest("Não deletado");
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(Discipline entity)
        {
            try
            {
                var disciplineEntity = await _service.Get(entity.Id);
                if(disciplineEntity != null)
                {
                    if(await _service.Update(entity))
                    {
                        return Ok("Atualizado");
                    }
                }

            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return BadRequest("Não foi possível atualizar o registro.");
        }
    }
}
