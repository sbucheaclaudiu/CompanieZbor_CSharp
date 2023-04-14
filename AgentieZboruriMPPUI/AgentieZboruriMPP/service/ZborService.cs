using AgentieZboruriMPP.repository;
using AgentieZboruriMPP.domain;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AgentieZboruriMPP.service
{
    public class ZborService
    {
        protected IRepoZbor repo;

        public ZborService(IRepoZbor repo)
        {
            this.repo = repo;
        }

        public List<Zbor> getAll()
        {
            return repo.getAll();
        }

        public List<Zbor> getZboruriDisponibile()
        {
            return repo.getZboruriDisponibile();
        }

        public List<Zbor> getZborbySearch(String destination, DateTime date)
        {
            List<Zbor> lst = repo.getAll();
            List<Zbor> lst_search = new List<Zbor>();
            foreach (var zbor in lst)
            {
                if (zbor.Data == date && zbor.Destination == destination && zbor.NrLocuriLibere != 0)
                {
                    lst_search.Add(zbor);
                }
            }

            return lst_search;
        }

        public List<String> getDestinations()
        {
            List<String> lst = repo.getDestinations();
            List<String> uniq = lst.Distinct().ToList();
            return uniq;
        }

        public void modifZborBilet(Zbor zbor, int nrBilete)
        {
            repo.modifZborBilet(zbor, nrBilete);
        }
        
        public Zbor getZborbyID(int ID)
        {
            Zbor zbor = this.repo.getById(ID);
            return zbor;
        }
    }
}