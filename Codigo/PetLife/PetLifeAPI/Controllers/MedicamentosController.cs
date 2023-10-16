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
    public class MedicamentosController : ControllerBase
    {
        private readonly IMedicamentoService medicamentoService;
        private readonly IMapper mapper;

        public MedicamentosController(IMedicamentoService medicamentoService, IMapper mapper)
        {
            this.medicamentoService = medicamentoService;
            this.mapper = mapper;
        }
        // GET: api/<MedicamentosController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaMedicamentos = medicamentoService.GetAll();
            if (listaMedicamentos == null)
                return NotFound();
            return Ok(listaMedicamentos);
        }

        // GET api/<MedicamentosController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Medicamento medicamento = medicamentoService.Get(id);
            if (medicamento == null)
                return NotFound();
            return Ok(medicamento);
        }
        // POST api/<MedicamentosController>
        [HttpPost]
        public ActionResult Post([FromBody] MedicamentoModel medicamentoModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var medicamento = mapper.Map<Medicamento>(medicamentoModel);
            medicamentoService.Create(medicamento);

            return Ok();
        }

        // PUT api/<PessoasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] MedicamentoModel medicamentoModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var medicamento = mapper.Map<Medicamento>(medicamentoModel);
            if (medicamento == null)
                return NotFound();

            medicamentoService.Edit(medicamento);

            return Ok();
        }

        // DELETE api/<MedicamentosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Medicamento medicamento = medicamentoService.Get(id);
            if (medicamento == null)
                return NotFound();

            medicamentoService.Delete(id);
            return Ok();
        }
    }
}
