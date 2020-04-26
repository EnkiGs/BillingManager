using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Common.EntityModels
{
    public class Wording : BaseEntity
    {
        public float Quantite { get; set; }

        [DisplayName("Prix unitaire")]
        public float PrixU { get; set; }

        [DisplayName("Description")]
        public string Content { get; set; }

        public Wording() { }

        /*public Wording(float Quantite, float PrixU, string Content)
        {
            this.Content = Content;
            this.Quantite = Quantite;
            this.PrixU = PrixU;
        }*/
    }
}
