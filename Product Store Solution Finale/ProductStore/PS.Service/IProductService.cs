using PS.Domain;
using PS.ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service
{
   public interface IProductService : IService<Product>
    {
        IEnumerable<Product> FindMost5ExpensiveProds();
        float UnavailableProductsPercentage();
        void DeleteOldProds();
    }

}
