using AgentieZboruriMPP.domain;
using System.Collections.Generic;
using System;

namespace AgentieZboruriMPP.repository
{
    public interface IRepoZbor : IRepo<long, Zbor>
    {
        List<Zbor> getZborbySearch(String destination, DateTime date);
        List<String> getDestinations();
        List<Zbor> getZboruriDisponibile();
        void modifZborBilet(Zbor zbor, int nrBilete);
    }
}