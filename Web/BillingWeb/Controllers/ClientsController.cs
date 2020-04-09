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
            var client = await clientService.GetClient(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            var model = new ClientCreationViewModel();
            model.countries = GetAllCountries();
            return View(model);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Statut,Societe,Civil,Nom,Prenom,Adresse,Pays,CP,Ville,Email,Tel,Id")] Client client)
        {
            if (ModelState.IsValid)
            {
                clientService.AddClient(client);
                return RedirectToAction(nameof(Index));
            }
            var model = new ClientCreationViewModel();
            model.countries = GetAllCountries();
            model.client = client;
            return View(model);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var client = await clientService.GetClient(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Statut,Societe,Civil,Nom,Prenom,Adresse,Pays,CP,Ville,Email,Tel,Id")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    clientService.UpdateClient(client);
                }
                catch (DbUpdateConcurrencyException) when (clientService.GetClient(client.Id) == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var client = await clientService.GetClient(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            clientService.DeleteClient(id);
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

            objDict.Find(o => o.Text == RegionInfo.CurrentRegion.DisplayName).Selected = true;

            return objDict.OrderBy(p => p.Text);
        }

    }
}
