using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.University.Disciplines;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Discipline model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(await _service.Add(model))
                    {
                        return Ok("Cadastrado com sucesso");
                    }
                }
                return BadRequest("não foi possível adicionar");
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
