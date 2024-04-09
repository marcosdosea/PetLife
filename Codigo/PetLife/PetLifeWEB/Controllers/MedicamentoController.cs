using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using PetLifeWEB.Models;

namespace PetLifeWEB.Controllers
{
    [Authorize]
    public class MedicamentoController : Controller
    {
        private readonly IMedicamentoService _medicamentoService;
        private readonly IMapper _mapper;

        public MedicamentoController(IMedicamentoService medicamentoService, IMapper mapper)
        {
            _medicamentoService = medicamentoService;
            _mapper = mapper;
        }

       // [Authorize(Roles = "TUTOR")]
        // GET: MedicamentoController
        public ActionResult Index()
        {
            var listaMedicamento = _medicamentoService.GetAll();
            var listaMedicamentoModel = _mapper.Map<List<MedicamentoModel>>(listaMedicamento);
            return View(listaMedicamentoModel);
        }

        // GET: MedicamentoController/Details/5
        public ActionResult Details(uint id)
        {
            Medicamento medicamento = _medicamentoService.Get(id);
            MedicamentoModel medicamentoModel = _mapper.Map<MedicamentoModel>(medicamento);
            return View(medicamentoModel);
        }

        // GET: MedicamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicamentoModel medicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var medicamento = _mapper.Map<Medicamento>(medicamentoModel);
                _medicamentoService.Create(medicamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MedicamentoController/Edit/5
        public ActionResult Edit(uint id)
        {
            Medicamento medicamento = _medicamentoService.Get(id);
            MedicamentoModel medicamentoModel = _mapper.Map<MedicamentoModel>(medicamento);
            return View(medicamentoModel);
        }

        // POST: MedicamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, MedicamentoModel medicamentoModel)
        {
            if (ModelState.IsValid)
            {
                var medicamento = _mapper.Map<Medicamento>(medicamentoModel);
                _medicamentoService.Edit(medicamento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MedicamentoController/Delete/5
        public ActionResult Delete(uint id)
        {
            Medicamento medicamento = _medicamentoService.Get(id);
            MedicamentoModel medicamentoModel = _mapper.Map<MedicamentoModel>(medicamento);
            return View(medicamentoModel);
        }

        // POST: MedicamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, IFormCollection collection)
        {
            _medicamentoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
