using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Common.EntityModels
{
    public class Client : BaseEntity, IComparable
    {
        [Required(ErrorMessage = "Le statut est obligatoire")]
        public Statute Statut { get; set; }
        public string Societe { get; set; }

        [DisplayName("Civilité")]
        [Required(ErrorMessage = "La civilité est obligatoire")]
        public Title Civil { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Pays { get; set; }

        [DisplayName("Code postal")]
        public string CP { get; set; }
        public string Ville { get; set; }
        [Required(ErrorMessage = "L'email est obligatoire")]
        [RegularExpression(@"^[a-zA-Z0-9_.-]+@{1}[a-zA-Z0-9_.-]{2,}\.[a-zA-Z0-9_.-]{2,4}$", ErrorMessage = "Le format de l'email n'est pas valide.")]
        public string Email { get; set; }

        [DisplayName("Téléphone")]
        [RegularExpression(@"^(?:(?:\+|00)33|0|\(\d{3}\))\s*[1-9]?((?:[\s.-]*\d{2}){4}|(?:[\s.-]*\d{3}){3})$", ErrorMessage = "Le numéro de téléphone n'est pas valide.")]
        public string Tel { get; set; }

        public ICollection<Document> Documents { get; set; }

        public Client() {
            Statut = Statute.Particulier;
            Societe = string.Empty;
            Civil = Title.Société;
            Nom = string.Empty;
            Prenom = string.Empty;
            Adresse = string.Empty;
            Pays = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            CP = string.Empty;
            Ville = string.Empty;
            Email = string.Empty;
            Tel = string.Empty;
            Documents = new Collection<Document>();
        }

        public override string ToString()
        {
            if (Societe != null && Societe != "")
                return Societe;
            return Nom + Prenom;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            var objet = obj as Client;
            if ((Societe == null || Societe == "") && (objet.Societe == null || objet.Societe == ""))
                return Nom.CompareTo(objet.Nom);

            else if ((Societe == null || Societe == "") || (objet.Societe == null || objet.Societe == ""))
            {
                if (Societe == null || Societe == "")
                    return Nom.CompareTo(objet.Societe);
                else
                    return Societe.CompareTo(objet.Nom);
            }
            return Societe.CompareTo(objet.Societe);
        }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   (Civil == Title.Société ? 
                        Societe.Equals(client.Societe) :
                        (Nom == client.Nom && Prenom == client.Prenom));
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(Statut);
            hash.Add(Societe);
            hash.Add(Civil);
            hash.Add(Nom);
            hash.Add(Prenom);
            hash.Add(Adresse);
            hash.Add(Pays);
            hash.Add(CP);
            hash.Add(Ville);
            hash.Add(Email);
            hash.Add(Tel);
            return hash.ToHashCode();
        }
    }
}
