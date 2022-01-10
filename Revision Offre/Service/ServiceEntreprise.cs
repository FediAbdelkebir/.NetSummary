using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class ServiceEntreprise : Service<Entreprise>, IServiceEntreprise
    {
        public ServiceEntreprise(IUnitOfWork utwk) : base(utwk)
        {

        }
        //Service3
        public IEnumerable<Entreprise> Top2Entreprise()
        {
            IDataBaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);
            var linq = (from i in utwk.getRepository<Offre>().GetMany()
                        join j in GetMany() on i.Entreprise.IdEntreprise equals j.IdEntreprise
                        where i.TypeContrat == "Stage"
                        orderby i.Postulants.Count()
                        select j).Take(2);
            return linq;
        }

        //Service4
        public int NbrPME()
        {

            return GetMany().Where(p => (p.Effectif > 10) && (p.Effectif < 250) && (p.ChiffreAffaire < 50000000)).Count();

        }
        //Service5
        public IEnumerable<IGrouping<Secteur,Entreprise>> ParSecteur(string ville)
        {
            var query = from entreprise in GetMany(p => (p.AdresseEntreprise.Ville.Equals(ville)))
                        group entreprise by entreprise.Secteur into newGroup
                        orderby newGroup.Key
                        select newGroup;
            return query;
        }
    }
}