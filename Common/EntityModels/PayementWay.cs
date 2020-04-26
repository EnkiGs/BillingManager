using System.ComponentModel.DataAnnotations;

namespace Common.EntityModels
{
    public enum PayementWay
    {
        [Display(Name = "Non payé")]
        Non_payé ,
        Carte,
        Virement,
        Chèque,
        Espèces,
        Autre
    }
}
