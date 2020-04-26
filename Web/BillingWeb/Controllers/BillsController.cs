using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Common.EntityModels;
using Professional.BusinessInterfaces.Services.Interfaces;
using System;
using Web.BillingWeb.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.BillingWeb.Controllers
{
    public class BillsController : Controller
    {
        private readonly IBillService billService;
        private readonly IClientService clientService;

        public BillsController(IBillService billService, IClientService clientService)
        {
            this.billService = billService;
            this.clientService = clientService;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var model = new List<BillDisplayViewModel>();
            var bills = await billService.GetBills();
            foreach (var bill in bills)
            {
                string clientName = await clientService.GetClientName(bill.ClientId);
                model.Add(new BillDisplayViewModel()
                {
                    bill = bill,
                    clientName = clientName
                });
            }
            return View(model);
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            var model = new BillDisplayViewModel();
            model.bill = await billService.GetBill(id);
            if (model.bill == null)
            {
                return NotFound();
            }
            model.clientName = await clientService.GetClientName(model.bill.ClientId);

            return View(model);
        }

        // GET: Bills/Create
        public async Task<IActionResult> Create()
        {
            var model = new BillEditionViewModel();
            model.Bill = new Bill();
            var currentYear = DateTime.Now.Year;
            model.Bill.Year = currentYear;
            model.Bill.Num = await billService.CountBillsForYear(currentYear) + 1;
            var liste = new List<SelectListItem>();
            var clients = await clientService.GetClients();
            foreach (var client in clients)
            {
                liste.Add(new SelectListItem(clientService.GetClientName(client), client.Id.ToString()));
            }
            model.Clients = liste;
            return View(model);
        }

        // POST: Bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Objet,Total,ModeR,Date,DateP,Id,Num,Year")] Bill bill, string clientSelect)
        {
            bill.ClientId = long.Parse(clientSelect);
            if (ModelState.IsValid)
            {
                await billService.AddBill(bill);
                return RedirectToAction(nameof(Index));
            }
            var model = new BillEditionViewModel();
            model.Bill = bill;
            var liste = new List<SelectListItem>();
            var clients = await clientService.GetClients();
            foreach (var client in clients)
            {
                liste.Add(new SelectListItem(clientService.GetClientName(client), client.Id.ToString()));
            }
            model.Clients = liste;
            return View(model);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var model = new BillEditionViewModel();
            model.Bill = await billService.GetBill(id);
            if (model.Bill == null)
            {
                return NotFound();
            }
            var liste = new List<SelectListItem>();
            var clients = await clientService.GetClients();
            var selected = false;
            foreach (var client in clients)
            {
                if(client.Id == model.Bill.ClientId)
                {
                    selected = true;
                }
                liste.Add(new SelectListItem(clientService.GetClientName(client), client.Id.ToString(), selected));
                selected = false;
            }
            model.Clients = liste;
            return View(model);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Num,Year,Objet,Total,ModeR,Date,DateP,Id")] Bill bill, string clientSelect)
        {
            if (id != bill.Id)
            {
                return NotFound();
            }
            bill.ClientId = long.Parse(clientSelect);
            if (ModelState.IsValid)
            {
                try
                {
                    await billService.UpdateBill(bill);
                }
                catch (DbUpdateConcurrencyException) when (billService.GetBill(bill.Id) == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bill);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var model = new BillDisplayViewModel();
            model.bill = await billService.GetBill(id);
            if (model.bill == null)
            {
                return NotFound();
            }
            model.clientName = await clientService.GetClientName(model.bill.ClientId);

            return View(model);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await billService.DeleteBill(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLibelle(BillEditionViewModel model)
        {
            if(model.Bill.LibelleList == null)
            {
                model.Bill.LibelleList = new List<Wording>();
            }
            model.Bill.LibelleList.Add(new Wording());
            return View("Create", model);
        }
    }
}
