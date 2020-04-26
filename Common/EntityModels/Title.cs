using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.EntityModels
{
    public enum Title
    {
        Société,
        Madame,
        Monsieur,
        [Display(Name = "Monsieur et Madame")]
        Monsieur_et_Madame,
        [Display(Name = "Monsieur ou Madame")]
        Monsieur_ou_Madame
    }
}
