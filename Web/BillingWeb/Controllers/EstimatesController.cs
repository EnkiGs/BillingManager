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

namespace Web.BillingWeb.Controllers
{
    public class EstimatesController : Controller
    {
        private readonly IEstimateService _estimateService;
        private readonly IClientService _clientService;
        private readonly IConverter _converter;

        public EstimatesController(IEstimateService estimateService, IClientService clientService, IConverter converter)
        {
            _estimateService = estimateService;
            _clientService = clientService;
            _converter = converter;
        }

        // GET: Estimates
        public async Task<IActionResult> Index()
        {
            var model = new List<EstimateDisplayViewModel>();
            var estimates = await _estimateService.GetEstimates();
            foreach (var estimate in estimates)
            {
                string clientName = await _clientService.GetClientName(estimate.ClientId);
                model.Add(new EstimateDisplayViewModel()
                {
                    estimate = estimate,
                    clientName = clientName
                });
            }
            return View(model);
        }

        // GET: Estimates/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            EstimateViewModel model = new EstimateViewModel
            {
                Estimate = await _estimateService.GetEstimate(id)
            };
            if (model.Estimate == null)
            {
                return NotFound();
            }
            List<SelectListItem> liste = new List<SelectListItem>();
            IEnumerable<Client> clients = await _clientService.GetClients();
            bool selected = false;
            foreach (Client client in clients)
            {
                if (client.Id == model.Estimate.ClientId)
                {
                    selected = true;
                }
                liste.Add(new SelectListItem(_clientService.GetClientName(client), client.Id.ToString(), selected));
                selected = false;
            }
            model.Clients = liste;

            return View(model);
        }

        // GET: Estimates/Pdf/5
        public async Task<IActionResult> Pdf(long? id)
        {
            if (id.HasValue)
            {
                var model = new EstimateDisplayViewModel();
                model.estimate = await _estimateService.GetEstimate(id);
                if (model.estimate == null)
                {
                    return NotFound();
                }
                model.clientName = await _clientService.GetClientName(model.estimate.ClientId);

                string filename = "Devis_" + model.clientName + "_" + model.estimate.Num + "_" + model.estimate.Year;

                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "Devis " + model.estimate.Num + " " + model.estimate.Year,
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

        // GET: Estimates/Create
        public async Task<IActionResult> Create()
        {
            var model = new EstimateViewModel();
            model.Estimate = new Estimate();
            var currentYear = DateTime.Now.Year;
            model.Estimate.Year = currentYear;
            model.Estimate.Num = await _estimateService.CountEstimatesForYear(currentYear) + 1;
            model.Estimate.LibelleList = new List<Wording>();
            model.Estimate.LibelleList.Add(new Wording());
            var liste = new List<SelectListItem>();
            var clients = await _clientService.GetClients();
            foreach (var client in clients)
            {
                liste.Add(new SelectListItem(_clientService.GetClientName(client), client.Id.ToString()));
            }
            model.Clients = liste;
            return View("Details", model);
        }

        // POST: Estimates/PostEstimate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostEstimate(EstimateViewModel model, string clientSelect)
        {
            model.Estimate.ClientId = long.Parse(clientSelect);
            if (ModelState.IsValid)
            {
                if (model.Estimate.Id == 0)
                {
                    await _estimateService.AddEstimate(model.Estimate);
                }
                else
                {
                    try
                    {
                        await _estimateService.UpdateEstimate(model.Estimate);
                    }
                    catch (DbUpdateConcurrencyException) when (_estimateService.GetEstimate(model.Estimate.Id) == null)
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
                if (client.Id == model.Estimate.ClientId)
                {
                    selected = true;
                }
                liste.Add(new SelectListItem(_clientService.GetClientName(client), client.Id.ToString(), selected));
                selected = false;
            }
            model.Clients = liste;
            return View("Details", model);
        }

        // POST: Estimates/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (await _estimateService.GetEstimate(id) == null)
            {
                return NotFound();
            }
            await _estimateService.DeleteEstimate(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IEnumerable<string>> GetRegularObjects()
        {
            return await _estimateService.GetRegularObjects();
        }

        public async Task<IEnumerable<string>> GetRegularDescriptions()
        {
            return await _estimateService.GetRegularDescriptions();
        }
    }
}
