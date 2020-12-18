using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTS.Data;
using MTS.Data.Entities;
using MTS.Engine.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Controllers
{
    public class ClientController : Controller
    {
        private readonly IDbSetProvider<Client> _provider;
        public ClientController(IDbSetProvider<Client> provider, PostgresContext context)
        {
            _provider = provider.Build(context.Clients, context);
        }
        // GET: ClientController
        public ActionResult Index()
        {
            var list = _provider.GetQueryable().ToList();
            return View(list);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            var list = _provider.GetQueryable();
            var obj = list.Where(x => x.Id == id).FirstOrDefault();
            return View(obj);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client obj)
        {
            try
            {
                obj.RegistrationDate = DateTimeOffset.Now;
                _provider.InsertAsync(obj).GetAwaiter().GetResult();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            var list = _provider.GetQueryable();
            var obj = list.Where(x => x.Id == id).FirstOrDefault();
            return View(obj);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client obj)
        {
            try
            {
                _provider.UpdateAsync(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
