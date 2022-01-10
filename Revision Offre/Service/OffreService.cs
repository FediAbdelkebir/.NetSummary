using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class OffreService : Service<Offre>, IOffreService

    {
        public OffreService(IUnitOfWork utwk) : base(utwk)
        {

        }
        //Service1
        public IEnumerable<Offre> OffresMoisEnCours()
        {
            return GetMany(o => (o.DatePublication.Month == DateTime.Now.Month)
                        && (o.DatePublication.Year == DateTime.Now.Year));

        }
    }
}
