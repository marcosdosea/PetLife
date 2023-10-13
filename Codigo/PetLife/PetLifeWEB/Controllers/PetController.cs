using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using PetLifeWEB.Models;

namespace PetLifeWEB.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public PetController(IPetService petService, IMapper mapper)
        {
            _petService = petService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listaPets = _petService.GetAll();
            var listaPetsModel = _mapper.Map<List<PetModel>>(listaPets);
            return View(listaPetsModel);
        }

        public ActionResult Details(uint id)
        {
            Pet pet = _petService.Get(id);
            PetModel petModel = _mapper.Map<PetModel>(pet);
            return View(petModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetModel petModel)
        {
            if (ModelState.IsValid)
            {
                var pet = _mapper.Map<Pet>(petModel);
                _petService.Create(pet);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(uint id)
        {
            Pet pet = _petService.Get(id);
            PetModel petModel = _mapper.Map<PetModel>(pet);
            return View(petModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, PetModel petModel)
        {
            if (ModelState.IsValid)
            {
                var pet = _mapper.Map<Pet>(petModel);
                _petService.Edit(pet);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(uint id)
        {
            Pet pet = _petService.Get(id);
            PetModel petModel = _mapper.Map<PetModel>(pet);
            return View(petModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, PetModel petModel)
        {
            _petService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
