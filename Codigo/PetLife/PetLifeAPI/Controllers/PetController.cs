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
    public class PetController : ControllerBase
    {
        private readonly IPetService petService;
        private readonly IMapper mapper;

        public PetController(IPetService petService, IMapper mapper)
        {
            this.petService = petService;
            this.mapper = mapper;
        }
        // GET: api/<PetController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaPets = petService.GetAll();
            if (listaPets == null)
                return NotFound();
            return Ok(listaPets);
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Pet pet = petService.Get(id);
            if (pet == null)
                return NotFound();
            return Ok(pet);
        }
        // POST api/<PetController>
        [HttpPost]
        public ActionResult Post([FromBody] PetModel petModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var pet = mapper.Map<Pet>(petModel);
            petService.Create(pet);

            return Ok();
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] PetModel petModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var pet = mapper.Map<Pet>(petModel);
            if (pet == null)
                return NotFound();

            petService.Edit(pet);

            return Ok();
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Pet pet = petService.Get(id);
            if (pet == null)
                return NotFound();

            petService.Delete(id);
            return Ok();
        }
    }
}
