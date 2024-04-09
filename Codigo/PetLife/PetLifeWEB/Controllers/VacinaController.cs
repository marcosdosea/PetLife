using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using PetLifeWEB.Models;
using Microsoft.AspNetCore.Authorization;

namespace PetLifeWEB.Controllers 
    {
    [Authorize]
    public class VacinaController : Controller {
        private readonly IVacinaService _vacinaService;
        private readonly IMapper _mapper;

        public VacinaController(IVacinaService vacinaService, IMapper mapper) {
            _vacinaService = vacinaService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "TUTOR")]
        // GET: VacinaController
        public ActionResult Index() {
            var listaVacina = _vacinaService.GetAll();
            var listaVacinaModel = _mapper.Map<List<VacinaModel>>(listaVacina);
            return View(listaVacinaModel);
        }

        // GET: VacinaController/Details/5
        public ActionResult Details(uint id) {
            Vacina vacina = _vacinaService.Get(id);
            VacinaModel vacinaModel = _mapper.Map<VacinaModel>(vacina);
            return View(vacinaModel);
        }

        // GET: VacinaController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: MedicamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VacinaModel vacinaModel) {
            if(ModelState.IsValid) {
                var vacina = _mapper.Map<Vacina>(vacinaModel);
                _vacinaService.Create(vacina);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VacinaController/Edit/5
        public ActionResult Edit(uint id) {
            Vacina vacina = _vacinaService.Get(id);
            VacinaModel vacinaModel = _mapper.Map<VacinaModel>(vacina);
            return View(vacinaModel);
        }

        // POST: VacinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, VacinaModel vacinaModel) {
            if(ModelState.IsValid) {
                var vacina = _mapper.Map<Vacina>(vacinaModel);
                _vacinaService.Edit(vacina);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MedicamentoController/Delete/5
        public ActionResult Delete(uint id) {
            Vacina vacina = _vacinaService.Get(id);
            VacinaModel vacinaModel = _mapper.Map<VacinaModel>(vacina);
            return View(vacinaModel);
        }

        // POST: MedicamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, IFormCollection collection) {
            _vacinaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
