using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PS.Domain;

namespace GP.Service
{
    public class ManageProduct
    {
        public List<Product> products;
        
        public Func<string, List<Product>> FindProducts;
        public Action<Category> ScanProduct;
        public ManageProduct(List<Product> products)
        {
            this.products=products;
            #region Méthodes anonyme
            FindProducts = delegate (string c) {
                List<Product> list = new List<Product>();
                foreach (Product product in products)
                {
                    if (product.Name.ToUpper().StartsWith(c.ToUpper()))
                        list.Add(product);
                }
                return list;
            };

            ScanProduct = delegate (Category category)
            {
                foreach (Product product in products)
                {
                    if (product.MyCategory.Name.Equals(category.Name))
                        product.GetDetails();
                }

            };
            #endregion
            #region expression Lambda
            //FindProducts = (string c) => {
            //    List<Product> list = new List<Product>();
            //    foreach (Product product in products)
            //    {
            //        if (product.Name.ToUpper().StartsWith(c.ToUpper())) 
            //            list.Add(product);
            //    }
            //    return list;
            //};

            //ScanProduct = category =>
            //{
            //    foreach (Product product in this.products)
            //    {
            //        if (product.MyCategory.Name.Equals(category.Name))
            //            product.GetDetails();
            //    }

            //};
            #endregion
        }
        #region Méthodes de sélection
        public List<Product> Get5Chemical(double price)
        {
            var query = from product in products
                        where (product.Price > price)
                        select product;
            return query.Take(5).ToList<Product>();
        }
    
        public IEnumerable<Product> GetProductPrice(double price)
        {
            var query = from product in products
                        where (product.Price > price)
                        select product;
            return query.Skip(2); //par défaut AsEnumerable()
        }
        #endregion
        #region Méthodes d'agrégation + select ... new
        public double GetAveragePrice()
        {
            return (from product in products
                    select product.Price)
                    .Average();
        }
        public KeyValuePair<string, double> GetMaxPrice()
        {
            var query = (from product in products
                         select product.Price);
            var max = query.Max();

            var query2 = from product in products
                         where product.Price >= max
                         select new
                         {
                             name = product.Name,
                             price = product.Price
                         };

            var rst = query2.First();
            return new KeyValuePair<string, double>(rst.name, rst.price);

        }
        public int GetCountProduct(string city)
        {
            var query = from product in products
                        where product is Chemical
                        select product;

            var query2 = from product in query
                         where ((Chemical)product).MyAddress.City.Equals(city)
                         select product;
            return query2.Count();
        }
        #endregion
        #region OrderBy 
        public IOrderedEnumerable<Product> GetChemicalCity()
        {
            var query = from product in products
                        where product is Chemical
                        orderby ((Chemical)product).MyAddress.City ascending // ou descending
                        select product;
            return query;
        }
        public void GetChemicalGroupByCity()
        {
            var query = from product in products
                        where product is Chemical
                        orderby ((Chemical)product).MyAddress.City ascending // ou descending
                        group (Chemical)product by ((Chemical)product).MyAddress.City;
            foreach (var g in query)
            {
                System.Console.WriteLine(g.Key + ":");
                foreach (var k in g)
                {
                    System.Console.WriteLine("\t"+k.Name + " " + k.Price);
                }
            }
        }

        #endregion
    }
}
