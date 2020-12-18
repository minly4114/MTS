using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class CallController : Controller
    {
        private readonly IDbSetProvider<Call> _provider;
        private readonly IDbSetProvider<Client> _clientProvider;
        private readonly IDbSetProvider<Cost> _costProvider;
        public CallController(IDbSetProvider<Call> provider, IDbSetProvider<Client> clientProvider, IDbSetProvider<Cost> costProvider, PostgresContext context)
        {
            _provider = provider.Build(context.Calls, context);
            _clientProvider = clientProvider.Build(context.Clients, context);
            _costProvider = costProvider.Build(context.Costs, context);
        }
        // GET: CallController
        public ActionResult Index()
        {
            var list = _provider.GetQueryable().Include(x=>x.Client).Include(x=>x.Cost).Include(x => x.Payment).ToList();
            return View(list);
        }

        // GET: CallController/Details/5
        public ActionResult Details(int id)
        {
            var list = _provider.GetQueryable().Include(x => x.Client).Include(x=>x.Payment).Include(x=>x.Cost);
            var obj = list.Where(x => x.Id == id).FirstOrDefault();
            return View(obj);
        }

        // GET: CallController/Create
        public ActionResult Create()
        {
            ViewBag.Clients = new SelectList(_clientProvider.GetQueryable().Select(x=>new User { Id=x.Id, Name=$"{x.LastName} {x.FirstName} {x.PastName}"}).ToList(), "Id", "Name");
            ViewBag.Costs = new SelectList(_costProvider.GetQueryable().ToList(), "Id", "Locality");
            return View();
        }

        // POST: CallController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Call obj)
        {
            try
            {
                var call = FillCall(obj, false);
                _provider.InsertAsync(call).GetAwaiter().GetResult();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(obj);
            }
        }

        // GET: CallController/Edit/5
        public ActionResult Edit(int id)
        {
            var list = _provider.GetQueryable().Include(x => x.Client).Include(x => x.Cost).Include(x=>x.Payment);
            var obj = list.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.Clients = new SelectList(_clientProvider.GetQueryable().Select(x => new User { Id = x.Id, Name = $"{x.LastName} {x.FirstName} {x.PastName}" }).ToList(), "Id", "Name");
            ViewBag.Costs = new SelectList(_costProvider.GetQueryable().ToList(), "Id", "Locality");
            return View(obj);
        }

        // POST: CallController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Call obj)
        {
            try
            {
                var call = FillCall(obj, true);
                _provider.UpdateAsync(call).GetAwaiter().GetResult();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: CallController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CallController/Delete/5
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

        private Call FillCall(Call obj, bool existId)
        {
            var client = _clientProvider.GetQueryable().Where(x => x.Id == obj.Client.Id).FirstOrDefault();
            var cost = _costProvider.GetQueryable().Where(x => x.Id == obj.Cost.Id).FirstOrDefault();
            var call = new Call();
            if(obj.Payment != null)call.Payment= obj.Payment;
            if (existId) call.Id = obj.Id;
            call.Client = client;
            call.Cost = cost;
            var number = (obj.DateEnd - obj.DateStart).TotalMinutes;
            double preferentialNumber = 0;
            if ((obj.DateStart.Hour > 20 || obj.DateStart.Hour < 6) && (obj.DateEnd.Hour > 20 || obj.DateEnd.Hour < 6))
            {
                preferentialNumber = (obj.DateEnd - obj.DateStart).TotalMinutes;
            }
            else if (obj.DateStart.Hour > 20 || obj.DateStart.Hour < 6)
            {
                var dateEnd = new DateTimeOffset(obj.DateStart.Year, obj.DateStart.Month, obj.DateStart.Hour < 24 && obj.DateStart.Hour > 20 ? obj.DateStart.Day + 1 : obj.DateStart.Day, 6, 0, 0, 0, new TimeSpan(3, 0, 0));
                preferentialNumber = (dateEnd - obj.DateStart).TotalMinutes;
            }
            else if (obj.DateEnd.Hour > 20 || obj.DateEnd.Hour < 6)
            {
                var datestart = new DateTimeOffset(obj.DateEnd.Year, obj.DateEnd.Month, obj.DateStart.Hour < 24 && obj.DateStart.Hour > 20 ? obj.DateEnd.Day - 1 : obj.DateEnd.Day, 20, 0, 0, 0, new TimeSpan(3, 0, 0));
                preferentialNumber = (obj.DateEnd - datestart).TotalMinutes;
            }
            number = number - preferentialNumber;
            call.DateEnd = obj.DateEnd;
            call.DateStart = obj.DateStart;
            call.NumberOfMinutes = Convert.ToInt32(number);
            call.PreferentialNumberOfMinutes = Convert.ToInt32(preferentialNumber);
            call.Sum = (decimal)number * cost.Value + (decimal)preferentialNumber * cost.PreferentialValue;
            return call;
        }
    }
}
