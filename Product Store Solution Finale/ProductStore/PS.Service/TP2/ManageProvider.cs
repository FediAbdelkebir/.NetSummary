using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GP.Service
{
    public class ManageProvider
    {
        

        private List<Provider> Providers;

        public ManageProvider(List<Provider> providers)
        {
            this.Providers = providers;           
        }


        #region Syntaxe de base

        public List<Provider> GetProviderByName(string name)
        {
            var query = from provider in Providers
                        where provider.UserName.Contains(name)
                        select provider;
            return query.ToList<Provider>();
        }
        #endregion
        #region Méthode de sélection
        public Provider GetFirstProviderByName(string name)
        {
            var query = from provider in Providers
                        where provider.UserName.Contains(name)
                        select provider;
            return query.First();
            //si la selection est vide, utiliser FirstOrDefault
        }

        public Provider GetProviderById(int id)
        {
            var query = from provider in Providers
                        where provider.Id == id
                        select provider;
            return query.Single();
            //si la selection est vide, utiliser SingleOrDefault
        }


        #endregion

    }

}
