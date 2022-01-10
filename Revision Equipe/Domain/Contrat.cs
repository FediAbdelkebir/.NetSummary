using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Contrat
    {
       

        public DateTime DateContrat { get; set; }
        [Range(0,24)]
        public int DureeMois { get; set; }

        public double Salaire { get; set; }

        public int Identifiant { get; set; }


        //[ForeignKey("Membre")]
        public int MembreFk { get; set; }
        //[ForeignKey("Equipe")]
        public int EquipeFk { get; set; }


        //prop de navigation
        //[ForeignKey("MembreFk")]
        public virtual Membre Membre { get; set; }
        //[ForeignKey("EquipeFk")]
        public virtual Equipe Equipe { get; set; }
    }
}
