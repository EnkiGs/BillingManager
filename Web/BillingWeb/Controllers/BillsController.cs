using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Common.EntityModels;
using Professional.BusinessInterfaces.Services.Interfaces;
using System;
using Web.BillingWeb.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.IO;
using DinkToPdf.Contracts;
using DinkToPdf;
using Web.BillingWeb.Utility;
using System.Linq;

namespace Web.BillingWeb.Controllers
{
    public class BillsController : Controller
    {
        private readonly IBillService _billService;
        private readonly IClientService _clientService;
        private readonly IConverter _converter;

        public BillsController(IBillService billService, IClientService clientService, IConverter converter)
        {
            _billService = billService;
            _clientService = clientService;
            _converter = converter;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var model = new List<BillDisplayViewModel>();
            var bills = await _billService.GetBills();
            foreach (var bill in bills)
            {
                string clientName = await _clientService.GetClientName(bill.ClientId);
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
            BillViewModel model = new BillViewModel
            {
                Bill = await _billService.GetBill(id)
            };
            if (model.Bill == null)
            {
                return NotFound();
            }
            List<SelectListItem> liste = new List<SelectListItem>();
            IEnumerable<Client> clients = await _clientService.GetClients();
            bool selected = false;
            foreach (Client client in clients)
            {
                if (client.Id == model.Bill.ClientId)
                {
                    selected = true;
                }
                liste.Add(new SelectListItem(_clientService.GetClientName(client), client.Id.ToString(), selected));
                selected = false;
            }
            model.Clients = liste;

            return View(model);
        }

        // GET: Bills/Pdf/5
        public async Task<IActionResult> Pdf(long? id)
        {
            if (id.HasValue)
            {
                var model = new BillDisplayViewModel();
                model.bill = await _billService.GetBill(id);
                if (model.bill == null)
                {
                    return NotFound();
                }
                model.clientName = await _clientService.GetClientName(model.bill.ClientId);

                string filename = "Facture_" + model.clientName + "_" + model.bill.Num + "_" + model.bill.Year;

                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "Facture " + model.bill.Num + " " + model.bill.Year,
                };

                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = TemplateGenerator.GetHTMLString(model),
                    WebSettings = { DefaultEncoding = "utf-8",  UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", "pdf.css") },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true }
                };

                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                byte[] file = _converter.Convert(pdf);

                return File(file, "application/pdf", filename + ".pdf");
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        // GET: Bills/Create
        public async Task<IActionResult> Create()
        {
            var model = new BillViewModel();
            model.Bill = new Bill();
            var currentYear = DateTime.Now.Year;
            model.Bill.Year = currentYear;
            model.Bill.Num = await _billService.CountBillsForYear(currentYear) + 1;
            model.Bill.LibelleList = new List<Wording>();
            model.Bill.LibelleList.Add(new Wording());
            var liste = new List<SelectListItem>();
            var clients = await _clientService.GetClients();
            foreach (var client in clients)
            {
                liste.Add(new SelectListItem(_clientService.GetClientName(client), client.Id.ToString()));
            }
            model.Clients = liste;
            return View("Details", model);
        }

        // POST: Bills/PostBill
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostBill(BillViewModel model, string clientSelect)
        {
            model.Bill.ClientId = long.Parse(clientSelect);
            if (ModelState.IsValid)
            {
                if (model.Bill.Id == 0)
                {
                    await _billService.AddBill(model.Bill);
                }
                else
                {
                    try
                    {
                        await _billService.UpdateBill(model.Bill);
                    }
                    catch (DbUpdateConcurrencyException) when (_billService.GetBill(model.Bill.Id) == null)
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            List<SelectListItem> liste = new List<SelectListItem>();
            IEnumerable<Client> clients = await _clientService.GetClients();
            bool selected = false;
            foreach (Client client in clients)
            {
                if (client.Id == model.Bill.ClientId)
                {
                    selected = true;
                }
                liste.Add(new SelectListItem(_clientService.GetClientName(client), client.Id.ToString(), selected));
                selected = false;
            }
            model.Clients = liste;
            return View("Details", model);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (await _billService.GetBill(id) == null)
            {
                return NotFound();
            }
            await _billService.DeleteBill(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IEnumerable<string>> GetRegularObjects()
        {
            return await _billService.GetRegularObjects();
        }

        public async Task<IEnumerable<string>> GetRegularDescriptions()
        {
            return await _billService.GetRegularDescriptions();
        }
    }
}
