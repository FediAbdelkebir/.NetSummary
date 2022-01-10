using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
  public  class ServicePostulant : Service<Postulant>, IServicePostulant
    {
        public ServicePostulant(IUnitOfWork utwk) : base(utwk)
        {

        }
        //Service2
        public int NbrOffres(int id)
        {
            return GetMany().Where(p => p.IdPstulant == id).Select(p => p.Offres).Count();
        }
    }
}
