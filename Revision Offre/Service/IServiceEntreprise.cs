using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
  public  interface IServiceEntreprise: IService<Entreprise> 
    {
        IEnumerable<Entreprise> Top2Entreprise();
        int NbrPME();
        IEnumerable<IGrouping<Secteur, Entreprise>> ParSecteur(string ville);
    }
}
