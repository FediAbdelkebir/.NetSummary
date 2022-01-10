using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
 public   interface IOffreService:IService<Offre>
    {
        IEnumerable<Offre> OffresMoisEnCours();
    }
}
