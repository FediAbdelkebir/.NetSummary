using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
 public   interface IServicePostulant:IService<Postulant>
    {
        int NbrOffres(int id);
    }
}
