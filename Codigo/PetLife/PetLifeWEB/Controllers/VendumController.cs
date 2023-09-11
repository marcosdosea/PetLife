using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetLifeWEB.Models;
using Service;

namespace PetLifeWEB.Controllers
{
    public class VendumController : Controller
    {
        private readonly IVendumService _vendumService;
        private readonly IMapper _mapper;

        public VendumController(IVendumService vendumService, IMapper mapper)
        {
            _vendumService = vendumService;
            _mapper = mapper;
        }
        // GET: VendumController
        public ActionResult Index()
        {
            var listaVendum = _vendumService.GetAll();
            var listaVendumModel = _mapper.Map<List<VendumModel>>(listaVendum);
            return View(listaVendumModel);
        }

        // GET: VendumController/Details/5
        public ActionResult Details(int id)
        {
            Vendum vendum = _vendumService.Get(id);
            VendumModel vendumModel = _mapper.Map<VendumModel>(vendum);
            return View(vendumModel);
        }

        // GET: VendumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendumModel vendumModel)
        {
            if (ModelState.IsValid)
            {
                var vendum = _mapper.Map<Vendum>(vendumModel);
                _vendumService.Create(vendum);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VendumController/Edit/5
        public ActionResult Edit(int id)
        {
            Vendum vendum = _vendumService.Get(id); 
            VendumModel vendumModel = _mapper.Map<VendumModel>(vendum);
            return View(vendumModel);
        }

        // POST: VendumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VendumModel vendumModel)
        {
            if (ModelState.IsValid)
            {
                var vendum = _mapper.Map<Vendum>(vendumModel);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VendumController/Delete/5
        public ActionResult Delete(int id)
        {
            {
                Vendum vendum = _vendumService.Get(id);
                VendumModel vendumModel = _mapper.Map<VendumModel>(vendum);
                return View(vendumModel);
            }
            // POST: PessoaController/Delete/5
            
        }

        // POST: VendumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VendumModel vendumModel)
        {
            _vendumService.Delete(id);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
