using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Common.EntityModels;
using Professional.BusinessInterfaces.Services.Interfaces;
using System;

namespace Web.BillingWeb.Controllers
{
    public class BillsController : Controller
    {
        private readonly IBillService billService;

        public BillsController(IBillService billService)
        {
            this.billService = billService;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var bills = await billService.GetBills();
            return View(bills);
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            var bill = await billService.GetBill(id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        public async Task<IActionResult> Create()
        {
            var bill = new Bill();
            var currentYear = DateTime.Now.Year;
            bill.Year = currentYear;
            bill.Num = await billService.CountBillsForYear(currentYear);
            return View(bill);
        }

        // POST: Bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Ref,RefDeb,Objet,Total,ModeR,Date,mDate,DateP,ClientId,Id")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                billService.AddBill(bill);
                return RedirectToAction(nameof(Index));
            }
            return View(bill);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var bill = await billService.GetBill(id);
            if (bill == null)
            {
                return NotFound();
            }
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Num,Year,Objet,Total,ModeR,Date,mDate,DateP,ClientId,Id")] Bill bill)
        {
            if (id != bill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    billService.UpdateBill(bill);
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
            var bill = await billService.GetBill(id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            billService.DeleteBill(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
