using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
   public class Postulant
    {
        [Key]
        public int IdPstulant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
        public string Email { get; set; }

        //prop de navigation
        public virtual ICollection<Offre> Offres { get; set; }
    }
}
