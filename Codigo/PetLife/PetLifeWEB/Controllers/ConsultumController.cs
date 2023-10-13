using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using PetLifeWEB.Models;

namespace PetLifeWEB.Controllers
{
    public class ConsultumController : Controller
    {
        private readonly IConsultumService _consultumService;
        private readonly IMapper _mapper;

        public ConsultumController(IConsultumService consultumService, IMapper mapper)
        {
            _consultumService = consultumService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listaConsulta = _consultumService.GetAll();
            var listaConsultaModel = _mapper.Map<List<ConsultumModel>>(listaConsulta);
            return View(listaConsultaModel);
        }

        public ActionResult Details(uint id)
        {
            Consultum consultum = _consultumService.Get(id);
            ConsultumModel consultumModel = _mapper.Map<ConsultumModel>(consultum);
            return View(consultumModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsultumModel consultumModel)
        {
            if (ModelState.IsValid)
            {
                var consultum = _mapper.Map<Consultum>(consultumModel);
                _consultumService.Create(consultum);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(uint id)
        {
            Consultum consultum = _consultumService.Get(id);
            ConsultumModel consultumModel = _mapper.Map<ConsultumModel>(consultum);
            return View(consultumModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ConsultumModel consultumModel)
        {
            if (ModelState.IsValid)
            {
                var consultum = _mapper.Map<Consultum>(consultumModel);
                _consultumService.Edit(consultum);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(uint id)
        {
            Consultum consultum = _consultumService.Get(id);
            ConsultumModel consultumModel = _mapper.Map<ConsultumModel>(consultum);
            return View(consultumModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, ConsultumModel consultumModel)
        {
            _consultumService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
