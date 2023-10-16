using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core;
using Core.Service;
using PetLifeAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetLifeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinasController : ControllerBase
    {
        private readonly IVacinaService vacinaService;
        private readonly IMapper mapper;

        public VacinasController(IVacinaService vacinaService, IMapper mapper)
        {
            this.vacinaService = vacinaService;
            this.mapper = mapper;
        }
        // GET: api/<PessoasController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaVacinas = vacinaService.GetAll();
            if(listaVacinas == null)
                return NotFound();
            return Ok(listaVacinas);
        }

        // GET api/<PessoasController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Vacina vacina = vacinaService.Get(id);
            if(vacina == null)
                return NotFound();
            return Ok(vacina);
        }
        // POST api/<PessoasController>
        [HttpPost]
        public ActionResult Post([FromBody] VacinaModel vacinaModel)
        {
            if(!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var vacina = mapper.Map<Vacina>(vacinaModel);
            vacinaService.Create(vacina);

            return Ok();
        }

        // PUT api/<PessoasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] VacinaModel vacinaModel)
        {
            if(!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var vacina = mapper.Map<Vacina>(vacinaModel);
            if(vacina == null)
                return NotFound();

            vacinaService.Edit(vacina);

            return Ok();
        }

        // DELETE api/<PessoasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Vacina vacina = vacinaService.Get(id);
            if(vacina == null)
                return NotFound();

            vacinaService.Delete(id);
            return Ok();
        }
    }
}
