using Common.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.BillingWeb.Models
{
    public class BillViewModel
    {
        public Bill Bill { get; set; }

        public IEnumerable<SelectListItem> Clients { get; set; }
    }
}
