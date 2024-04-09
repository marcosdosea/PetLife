using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetLifeWEB.Models;
using Service;

namespace PetLifeWEB.Controllers
{
    [Authorize]
    public class PetshopController : Controller
    {
        private readonly IPetshopService _petshopService;
        private readonly IMapper _mapper;

        public PetshopController(IPetshopService petshopService, IMapper mapper) 
        {
            _petshopService = petshopService;
            _mapper = mapper;
        }

      //  [Authorize(Roles = "TUTOR")]
        // GET: PetshopController
        public ActionResult Index()
        {
            var listaPetshops = _petshopService.GetAll();
            var listaPetshopsModel = _mapper.Map<List<PetshopModel>>(listaPetshops);
            return View(listaPetshopsModel);
        }

        // GET: PetshopController/Details/5
        public ActionResult Details(uint id)
        {
            Petshop petshop = _petshopService.Get(id);
            PetshopModel petshopModel = _mapper.Map<PetshopModel>(petshop);
            return View(petshopModel);
        }

        // GET: PetshopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PetshopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetshopModel petshopModel)
        {
            if (ModelState.IsValid)
            {
                var petshop = _mapper.Map<Petshop>(petshopModel);
                _petshopService.Create(petshop);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: PetshopController/Edit/5
        public ActionResult Edit(uint id)
        {
            Petshop petshop = _petshopService.Get(id);
            PetshopModel petshopModel = _mapper.Map<PetshopModel>(petshop);
            return View(petshopModel);
        }

        // POST: PetshopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, PetshopModel petshopModel)
        {
            if (ModelState.IsValid)
            {
                var petshop = _mapper.Map<Petshop>(petshopModel);
                _petshopService.Edit(petshop);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PetshopController/Delete/5
        public ActionResult Delete(uint id)
        {
            Petshop petshop = _petshopService.Get(id);
            PetshopModel petshopModel = _mapper.Map<PetshopModel>(petshop);
            return View(petshopModel);
        }

        // POST: PetshopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, PetshopModel petshopModel)
        {
            _petshopService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
