using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.EntityModels
{
    public class Wording
    {
        public long Id { get; set; }

        public float Quantite { get; set; }

        [DisplayName("Prix unitaire")]
        public float PrixU { get; set; }

        [DisplayName("Description")]
        public string Content { get; set; }

        [ForeignKey("Doc")]
        public long DocId { get; set; }
        public Document Doc { get; set; }
    }
}
