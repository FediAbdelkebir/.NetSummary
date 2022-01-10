using Data.Infrastructure;
using Domain;
using Domaine;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
   public class ServiceEquipe:Service<Equipe>, IServiceEquipe
    {
        public ServiceEquipe(IUnitOfWork utwk) : base(utwk)
        {
        }
        //Service1
        public double Recompense(Equipe e) 
        {
            var req = GetMany().Select(eq => eq.Trophees);
            double somme = 0;
            foreach (Trophee t in req)
                somme = somme + t.Recompense;

            return somme;
        }
        //Service2
        public IEnumerable<Joueur> JoueursTrophee(Trophee t)
        {
            IDataBaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);
            var req = utwk.getRepository<Contrat>().
                GetMany(c => c.EquipeFk == t.EquipeFK && (t.DateTrophee - c.DateContrat).Days < c.DureeMois * 30)
                .Select(c => c.Membre).OfType<Joueur>();
            return req;
        }

        //Service3
        public IEnumerable<Entraineur> EntraineurEquipe(Equipe e)
        {
            IDataBaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);
            return utwk.getRepository<Contrat>().
                GetMany(c => c.EquipeFk == e.EquipeId).
                Select(c => c.Membre).OfType<Entraineur>();
        }
        
        //Service4
        public DateTime DatePremierChampionnat(Equipe e)
        {
            IDataBaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);
            return utwk.getRepository<Trophee>().
                   GetMany(t => t.TypeTrophee == "Championnat" && t.EquipeFK == e.EquipeId).
                   OrderBy(t => t.DateTrophee).
                   Select(t => t.DateTrophee).First();
        }

        public String EquipeMaxTrophees()
        {
            var req = from e in GetMany()
                      orderby e.Trophees.Count
                      select e.NomEquipe;
            return req.First();
        }

    }
}
