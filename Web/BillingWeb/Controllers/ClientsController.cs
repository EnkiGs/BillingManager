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
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var clients = await clientService.GetClients();
            return View(clients);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            var model = new ClientDisplayViewModel();
            model.client = await clientService.GetClient(id);
            if (model.client == null)
            {
                return NotFound();
            }
            model.Pays = GetCountryName(model.client.Pays);
            return View(model);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            var model = new ClientEditionViewModel();
            model.countries = GetAllCountries();
            model.client = new Client()
            {
                Pays = CultureInfo.CurrentCulture.TwoLetterISOLanguageName
            };
            return View(model);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Statut,Societe,Civil,Nom,Prenom,Adresse,Pays,CP,Ville,Email,Tel,Id")] Client client)
        {
            if (ModelState.IsValid)
            {
                await clientService.AddClient(client);
                return RedirectToAction(nameof(Index));
            }
            var model = new ClientEditionViewModel();
            model.countries = GetAllCountries();
            model.client = client;
            return View(model);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var model = new ClientEditionViewModel();
            model.client = await clientService.GetClient(id);
            if (model.client == null)
            {
                return NotFound();
            }
            model.countries = GetAllCountries();
            return View(model);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Statut,Societe,Civil,Nom,Prenom,Adresse,Pays,CP,Ville,Email,Tel,Id")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await clientService.UpdateClient(client);
                }
                catch (DbUpdateConcurrencyException) when (clientService.GetClient(client.Id) == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            var model = new ClientEditionViewModel();
            model.countries = GetAllCountries();
            model.client = client;
            return View(model);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var model = new ClientDisplayViewModel();
            model.client = await clientService.GetClient(id);
            if (model.client == null)
            {
                return NotFound();
            }
            model.Pays = GetCountryName(model.client.Pays);
            return View(model);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await clientService.DeleteClient(id);
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
