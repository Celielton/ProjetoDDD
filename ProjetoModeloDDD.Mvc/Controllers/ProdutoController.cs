using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.Mvc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }
        // GET: Produto
        public ActionResult Index()
        {
            var produtos = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoAppService.GetAll());
            return View(produtos);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var produto = Mapper.Map<Produto,ProdutoViewModel>(_produtoAppService.GetbyId(id));
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(ProdutoViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = Mapper.Map<ProdutoViewModel, Produto>(viewModel);
                    _produtoAppService.Add(model);

                    return RedirectToAction("Index");
                }

                return HttpNotFound();
            }
            catch(Exception ex)
            {
                return HttpNotFound();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = Mapper.Map<Produto, ProdutoViewModel>(_produtoAppService.GetbyId(id));
            return View(viewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(ProdutoViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = Mapper.Map<ProdutoViewModel, Produto>(viewModel);
                    _produtoAppService.Update(model);

                    return RedirectToAction("Index");
                }

                return HttpNotFound();
            }
            catch
            {
                return HttpNotFound();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = Mapper.Map<Produto, ProdutoViewModel>(_produtoAppService.GetbyId(id));
            return View(viewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(ProdutoViewModel vModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var model = Mapper.Map<ProdutoViewModel, Produto>(vModel);
                    _produtoAppService.Remove(model);

                    return RedirectToAction("Index");

                }
                return HttpNotFound();
            }
            catch
            {
                return HttpNotFound();
            }
        }
    }
}
