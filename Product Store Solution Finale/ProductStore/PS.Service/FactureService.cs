using PS.Data.Infrastructure;
using PS.Domain;
using PS.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Service
{
    public class FactureService : Service<Facture>, IFactureService
    {
      

        public FactureService(IUnitOfWork utwk, IUnitOfWork utwk1) : base(utwk)
        {
        }
        public IEnumerable<Product> GetProdsByClient(Client c)
        {
           
            var req = GetMany(f => f.ClientFk == c.CIN)
            .ToList()
            .Select(f => f.Product);
            return req;
        }

    }
}
