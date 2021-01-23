using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.EntityModels
{
    public enum Title
    {
        [Display(Name = "Société")]
        Société,
        [Display(Name = "Mme")]
        Madame,
        [Display(Name = "M.")]
        Monsieur,
        [Display(Name = "M. et Mme")]
        Monsieur_et_Madame,
        [Display(Name = "M. ou Mme")]
        Monsieur_ou_Madame
    }
}
