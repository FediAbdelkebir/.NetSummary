using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [Owned]
   public class Adresse
    {
        public string Ville { get; set; }
        public string Region { get; set; }
        public int CodePostal { get; set; }
    }
}
