using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.EntityModels
{
    public abstract class Document : BaseEntity
    {
        public int Year { get; set; }
        public int Num { get; set; }
        [Required(ErrorMessage = "L'objet est obligatoire")]
        public string Objet { get; set; }
        public double Total { get; set; }

        [DisplayName("Mode de paiement")]
        public PayementWay ModeR { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date de création")]
        public DateTime Date { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date de paiement")]
        public DateTime DateP { get; set; }

        public ICollection<Wording> LibelleList { get; set; }

        [ForeignKey("Client")]
        [DisplayName("Client")]
        public long ClientId { get; set; }

        public Client Client { get; set; }

        protected Document()
        {
            Id = 0;
            Year = 0;
            Num = 0;
            Objet = string.Empty;
            Total = 0;
            ModeR = PayementWay.Non_payé;
            Date = DateTime.Now;
            DateP = DateTime.Now;
            LibelleList = new Collection<Wording>();
            ClientId = -1;
            Client = null;
        }
    }
}
