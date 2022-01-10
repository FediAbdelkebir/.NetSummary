using PS.Domain;
using PS.ServicePattern;
using System.Collections.Generic;

namespace PS.Service
{
    public interface IFactureService : IService<Facture>
    {
        IEnumerable<Product> GetProdsByClient(Client c);
    }
}