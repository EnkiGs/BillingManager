using Common.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Web.BillingWeb.Models
{
    public class ClientViewModel
    {
        public Client client { get; set; }

        public IEnumerable<SelectListItem> countries { get; set; }
    }
}
