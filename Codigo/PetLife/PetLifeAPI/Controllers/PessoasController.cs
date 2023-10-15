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
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService pessoaService;
        private readonly IMapper mapper;

        public PessoasController(IPessoaService pessoaService, IMapper mapper)
        {
            this.pessoaService = pessoaService;
            this.mapper = mapper;
        }
        // GET: api/<PessoasController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaPessoas = pessoaService.GetAll();
            if (listaPessoas == null)
                return NotFound();
            return Ok(listaPessoas);
        }

        // GET api/<PessoasController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Pessoa pessoa = pessoaService.Get(id);
            if (pessoa == null)
                return NotFound();
            return Ok(pessoa);
        }
        // POST api/<PessoasController>
        [HttpPost]
        public ActionResult Post([FromBody] PessoaModel pessoaModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var pessoa = mapper.Map<Pessoa>(pessoaModel);
            pessoaService.Create(pessoa);

            return Ok();
        }

        // PUT api/<PessoasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] PessoaModel pessoaModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var pessoa = mapper.Map<Pessoa>(pessoaModel);
            if (pessoa == null)
                return NotFound();

            pessoaService.Edit(pessoa);

            return Ok();
        }

        // DELETE api/<PessoasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Pessoa pessoa = pessoaService.Get(id);
            if (pessoa == null)
                return NotFound();

            pessoaService.Delete(id);
            return Ok();
        }
    }
}
