using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTS.Data;
using MTS.Data.Entities;
using MTS.Engine.IProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IDbSetProvider<Payment> _provider;
        public PaymentController(IDbSetProvider<Payment> provider, PostgresContext context)
        {
            _provider = provider.Build(context.Payments, context);
        }
        // GET: PaymentController
        public ActionResult Index()
        {
            var list = _provider.GetQueryable().Include(x=>x.Call).ThenInclude(x=>x.Client).ToList();
            return View(list);
        }

        // GET: PaymentController/Details/5
        public ActionResult Details(int id)
        {
            var list = _provider.GetQueryable();
            var obj = list.Where(x => x.Id == id).FirstOrDefault();
            return View(obj);
        }

        // GET: PaymentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment obj)
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

        // GET: PaymentController/Edit/5
        public ActionResult Edit(int id)
        {
            var list = _provider.GetQueryable();
            var obj = list.Where(x => x.Id == id).FirstOrDefault();
            return View(obj);
        }

        // POST: PaymentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Payment obj)
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

        // GET: PaymentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentController/Delete/5
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
