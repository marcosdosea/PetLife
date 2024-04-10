using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetLifeWEB.Models;
using Service;
using System.Data;

namespace PetLifeWEB.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "TUTOR")]
        // GET: ProdutoController
        public ActionResult Index()
        {
            var listaProdutos = _produtoService.GetAll();
            var listaProdutosModel = _mapper.Map<List<ProdutoModel>>(listaProdutos);
            return View(listaProdutosModel);
        }

        // GET: ProdutoController/Details/5
        public ActionResult Details(uint id)
        {
            Produto produto = _produtoService.Get(id);
            ProdutoModel produtoModel = _mapper.Map<ProdutoModel>(produto);
            return View(produtoModel);
        }

        // GET: ProdutoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                var produto = _mapper.Map<Produto>(produtoModel);
                _produtoService.Create(produto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutoController/Edit/5
        public ActionResult Edit(uint id)
        {
            Produto produto = _produtoService.Get(id);
            ProdutoModel produtoModel = _mapper.Map<ProdutoModel>(produto);
            return View(produtoModel);
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                var produto = _mapper.Map<Produto>(produtoModel);
                _produtoService.Edit(produto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutoController/Delete/5
        public ActionResult Delete(uint id)
        {
            Produto produto = _produtoService.Get(id);
            ProdutoModel produtoModel = _mapper.Map<ProdutoModel>(produto);
            return View(produtoModel);
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, ProdutoModel produtoModel)
        {
            _produtoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
