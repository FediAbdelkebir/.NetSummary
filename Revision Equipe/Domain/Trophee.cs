using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
 
   public class Trophee
    {
        public int TropheeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTrophee { get; set; }

        [DataType(DataType.Currency)]
        public double Recompense { get; set; }
        public string TypeTrophee { get; set; }

        //prop de navigation
        public virtual Equipe Equipe { get; set; }
        public int EquipeFK { get; set; }
    }
}
