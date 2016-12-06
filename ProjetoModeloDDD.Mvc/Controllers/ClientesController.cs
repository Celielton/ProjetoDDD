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
    public class ClientesController : Controller
    {
        private readonly int itens = 2;
        private readonly IClienteAppService _clienteApp;
        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }
        // GET: Clientes
        [Route("Clientes/{pagina=1}")]
        public ActionResult Index(int? pagina)
        {
            var currentPage = pagina ?? 1;
            var clientes = _clienteApp.GetAll();
            this.ViewBag._pagina = currentPage;
            this.ViewBag._total = clientes.Count();
            var model = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(clientes.Skip((2 * currentPage - 1)).Take(2));
            return View(model);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var model = Mapper.Map<Cliente, ClienteViewModel>(_clienteApp.GetbyId(id));
            return View(model);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            try
            {
                var model = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
                _clienteApp.Add(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Mapper.Map<Cliente,ClienteViewModel>(_clienteApp.GetbyId(id));
            return View(model);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            try
            {
                var model = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var model = Mapper.Map<Cliente,ClienteViewModel>(_clienteApp.GetbyId(id));
            return View(model);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(ClienteViewModel cliente)
        {
            try
            {
                _clienteApp.Remove(Mapper.Map<ClienteViewModel, Cliente>(cliente));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
