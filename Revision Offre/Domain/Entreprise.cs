using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
  public enum Secteur {Informatique, Energie, Immobilier, Finance, Autres }
  public  class Entreprise
    {
        public int ChiffreAffaire { get; set; }
        [DataType(DataType.Date)]
         public DateTime DateFondation { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Effectif { get; set; }
        [Key]
        public int IdEntreprise { get; set; }
        public string NomEntreprise { get; set; }
        
        public Secteur Secteur { get; set; }
        public Adresse AdresseEntreprise { get; set; }

        //prop de navigation
        public virtual ICollection<Offre> Offres { get; set; }
    }
}
