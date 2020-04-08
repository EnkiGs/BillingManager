using System;
using System.Collections.Generic;
using System.Text;

namespace Common.EntityModels
{
    public class Wording : BaseEntity
    {
        public float Quantite { get; set; }
        public float PrixU { get; set; }

        public string Content;

        public Wording() { }

        /*public Wording(float Quantite, float PrixU, string Content)
        {
            this.Content = Content;
            this.Quantite = Quantite;
            this.PrixU = PrixU;
        }*/
    }
}
