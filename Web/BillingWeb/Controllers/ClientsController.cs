using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Common.EntityModels;
using Data.DataAccess;
using Professional.BusinessInterfaces.Services.Interfaces;
using System.Globalization;
using Web.BillingWeb.Models;

namespace Web.BillingWeb.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            this._clientService = clientService;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetClients();
            return View(clients);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            var model = new ClientViewModel();
            model.client = await _clientService.GetClient(id);
            if (model.client == null)
            {
                return NotFound();
            }
            model.countries = GetAllCountries();
            model.countries.First(c => c.Value == model.client.Pays).Selected = true;
            return View(model);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            var model = new ClientViewModel
            {
                countries = GetAllCountries(),
                client = new Client()
            };
            return View("Details", model);
        }

        // POST: Clients/PostClient
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostClient(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.client.Id == 0)
                {
                    await _clientService.AddClient(model.client);
                }
                else
                {
                    try
                    {
                        await _clientService.UpdateClient(model.client);
                    }
                    catch (DbUpdateConcurrencyException) when (_clientService.GetClient(model.client.Id) == null)
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View("Details", model);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (await _clientService.GetClient(id) == null)
            {
                return NotFound();
            }
            await _clientService.DeleteClient(id);
            return RedirectToAction(nameof(Index));
        }

        private IEnumerable<SelectListItem> GetAllCountries()
        {
            var objDict = new List<SelectListItem>();
            foreach (var cultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                var regionInfo = new RegionInfo(cultureInfo.Name);
                if (!objDict.Exists(o => o.Text == regionInfo.DisplayName))
                {
                    objDict.Add(new SelectListItem(regionInfo.DisplayName, regionInfo.TwoLetterISORegionName.ToLower()));
                }
            }

            return objDict.OrderBy(p => p.Text);
        }

        private string GetCountryName(string TwoLetterISORegionName)
        {
            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(c => new RegionInfo(c.Name)).Distinct()
                .SingleOrDefault(r => r.TwoLetterISORegionName.ToLower() == TwoLetterISORegionName)?
                .DisplayName;
        }

    }
}
