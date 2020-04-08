using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.EntityModels
{
    public abstract class Document : BaseEntity
    {
        public string Ref { get; set; }
        public int RefDeb { get; set; }
        public string Objet { get; set; }
        public double Total { get; set; }
        public PayementWay ModeR { get; set; }

        public virtual string Date
        {
            get
            {
                return mDate.ToString("dd/MM/yy");
            }
            private set
            {
                mDate = DateTime.Parse(value);
            }
        }
        public DateTime mDate { get; set; }

        public virtual string DateP
        {
            get
            {
                return mDateP.ToString("dd/MM/yy");
            }
            private set
            {
                if (value == null)
                    value = "01/01/0001";
                mDateP = DateTime.Parse(value);
            }
        }
        private DateTime mDateP;

        public ICollection<Wording> LibelleList;

        [ForeignKey("Client")]
        public Guid ClientId { get; set; }


        public virtual Client Client { get; }

        protected Document() { }

        /*protected Document(Client Client, string Ref, string Date, string Objet, List<Wording> LibelleList, double Total, PayementWay ModeR, string DateP)
        {
            Id = Guid.NewGuid();
            this.Client = Client;
            this.Date = Date;
            this.Ref = Ref + mDate.Year.ToString();
            try
            {
                RefDeb = int.Parse(this.Ref.Substring(0, 2));
            }
            catch
            {
                RefDeb = int.Parse(this.Ref.Substring(0, 1));
            }
            this.Objet = Objet;
            this.LibelleList = LibelleList;
            this.Total = Total;
            this.ModeR = ModeR;
            this.DateP = DateP;

        }*/
    }
}
