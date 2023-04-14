using AgentieZboruriMPP.domain;
using AgentieZboruriMPP.repository;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AgentieZboruriMPP.service
{
    public class BiletService
    {
        protected IRepoBilet repo;

        public BiletService(IRepoBilet repo)
        {
            this.repo = repo;
        }
        public List<Bilet> getAll()
        {
            return this.repo.getAll();
        }

        public void addBilet(String numeClient, String numeTuristi, String adresa, int nrBilete, Zbor zbor)
        {
            List<Bilet> lst = getAll();
            long max = 1L;

            if (lst.Count() != 0)
            {
                var lst_id = new List<long>();

                foreach (Bilet m in lst)
                {
                    lst_id.Add(m.getId());
                }

                max = lst_id.Max();
            }

            Bilet bilet = new Bilet(max + 1, numeClient, numeTuristi, adresa, nrBilete, zbor);
            this.repo.insert(bilet);
        }
    }
}