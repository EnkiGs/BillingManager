using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Common.EntityModels
{
    public class Client : BaseEntity, IComparable
    {
        public Statute Statut { get; set; }
        public string Societe { get; set; }

        [DisplayName("Civilité")]
        public Title Civil { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Pays { get; set; }

        [DisplayName("Code postal")]
        public string CP { get; set; }
        public string Ville { get; set; }
        public string Email { get; set; }

        [DisplayName("Téléphone")]
        public string Tel { get; set; }

        public Client() { }

        /*public Client(Statute Statut, String Societe, Title Civil, String Nom, String Prenom, String Adresse, String CP, String Ville, String Email, String Tel)
        {
            Pays = "France";
            this.Statut = Statut;
            this.Societe = Societe;
            this.Civil = Civil;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Adresse = Adresse;
            this.CP = CP;
            this.Ville = Ville;
            this.Email = Email;
            this.Tel = Tel;
        }*/

        public override string ToString()
        {
            if (Societe != null && Societe != "")
                return Societe;
            return Nom;
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
