using PS.Data.Infrastructure;
using PS.Domain;
using PS.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Service
{
   public class ProductService: Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork utwk) : base(utwk)
        {
        }
        
        public IEnumerable<Product> FindMost5ExpensiveProds()
        {
            return GetMany().OrderByDescending(p => p.Price).Take(5);
        }

        public float UnavailableProductsPercentage()
        {
            int nbUnavailable = (from p in GetMany(p => p.Quantity == 0)
                                 select p).Count();
            int nbProds = GetMany().Count();
            return ((float)nbUnavailable / nbProds) * 100;
        }
        public void DeleteOldProds()
        {
            var req = GetMany().Where(p => (DateTime.Now - p.DateProd).TotalDays > 365);
            foreach (Product p in req)
                Delete(p);
            Commit();
        }





    }


    
}
