using Common.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Web.BillingWeb.Models
{
    public class ClientEditionViewModel
    {
        public Client client;

        public IEnumerable<SelectListItem> countries;
    }
}
