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
    public class CostController : Controller
    {
        private readonly IDbSetProvider<Cost> _provider;
        public CostController(IDbSetProvider<Cost> provider, PostgresContext context)
        {
            _provider = provider.Build(context.Costs, context);
        }
        // GET: CostController
        public ActionResult Index()
        {
            var list = _provider.GetQueryable().ToList();
            return View(list);
        }

        // GET: CostController/Details/5
        public ActionResult Details(int id)
        {
            var list = _provider.GetQueryable();
            var obj = list.Where(x => x.Id == id).FirstOrDefault();
            return View(obj);
        }

        // GET: CostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cost obj)
        {
            try
            {
                _provider.InsertAsync(obj).GetAwaiter().GetResult();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CostController/Edit/5
        public ActionResult Edit(int id)
        {
            var list = _provider.GetQueryable();
            var obj = list.Where(x => x.Id == id).FirstOrDefault();
            return View(obj);
        }

        // POST: CostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cost obj)
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

        // GET: CostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CostController/Delete/5
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
