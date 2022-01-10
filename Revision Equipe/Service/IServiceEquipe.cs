using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
 public   interface IServiceEquipe:IService<Equipe>
    {
        double Recompense(Equipe e);
    }
}
