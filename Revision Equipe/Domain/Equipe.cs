using Domaine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Equipe
    {
        public int EquipeId { get; set; }
        public string AdresseLocal { get; set; }
        public string Logo { get; set; }
        public string NomEquipe { get; set; }

        //prop de navigation
        public virtual ICollection<Contrat> Contrats { get; set; }
        public virtual ICollection<Trophee> Trophees { get; set; }
    }
}
