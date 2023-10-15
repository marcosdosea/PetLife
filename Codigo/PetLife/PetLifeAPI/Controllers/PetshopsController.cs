using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Mvc;
using PetLifeAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetLifeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetshopsController : ControllerBase
    {
        private readonly IPetshopService petshopService;
        private readonly IMapper mapper;

        public PetshopsController(IPetshopService petshopService, IMapper mapper)
        {
            this.petshopService = petshopService;
            this.mapper = mapper;
        }
        // GET: api/<PetshopsController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaPetshop = petshopService.GetAll();
            if (listaPetshop == null)
                return NotFound();
            return Ok(listaPetshop);
        }

        // GET api/<PetshopsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            Petshop petshop = petshopService.Get(id);
            if (petshop == null)
                return NotFound();
            return Ok(petshop);
        }
        // POST api/<PetshopsController>
        [HttpPost]
        public ActionResult Post([FromBody] PetshopModel petshopModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var petshop = mapper.Map<Petshop>(petshopModel);
            petshopService.Create(petshop);

            return Ok();
        }

        // PUT api/<PetshopsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] PetshopModel petshopModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var petshop = mapper.Map<Petshop>(petshopModel);
            if (petshop == null)
                return NotFound();

            petshopService.Edit(petshop);

            return Ok();
        }

        // DELETE api/<PetshopsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Petshop petshop = petshopService.Get(id);
            if (petshop == null)
                return NotFound();

            petshopService.Delete(id);
            return Ok();
        }
    }
}
