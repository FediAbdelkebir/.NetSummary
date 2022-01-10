using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class Offre

    {
       [Key]
        public int IdOffre { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePublication { get; set; }
        public string TitreOffre { get; set; }
        public string TypeContrat { get; set; }
        [ForeignKey("Entreprise")]
        public int EntrepriseFK { get; set; }

        //prop de navigation
        public virtual Entreprise Entreprise { get; set; }
        public virtual ICollection<Postulant> Postulants { get; set; }
    }
}
