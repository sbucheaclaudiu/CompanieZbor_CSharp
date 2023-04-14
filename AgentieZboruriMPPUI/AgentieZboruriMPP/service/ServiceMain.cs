using AgentieZboruriMPP.domain;
using System;
using System.Collections.Generic;

namespace AgentieZboruriMPP.service
{
    public class ServiceMain
    {
        private UserService userSrv;
        private ZborService zborService;
        private BiletService biletService;

        public ServiceMain(UserService userSrv, ZborService zborService, BiletService biletService)
        {
            this.userSrv = userSrv;
            this.zborService = zborService;
            this.biletService = biletService;
        }
        public List<User> getAllUser() { return this.userSrv.getAll(); }

        public List<Zbor> getAllZbor() { return this.zborService.getAll(); }

        public List<Bilet> getAllBilet() { return this.biletService.getAll(); }

        public User findUser(String username, String password)
        {
            return this.userSrv.findUser(username, password);
        }

        public List<Zbor> getZborbySearch(String destination, DateTime date)
        {
            return this.zborService.getZborbySearch(destination, date);
        }

        public List<String> getDestinations()
        {
            return this.zborService.getDestinations();
        }

        public List<Zbor> getZboruriDisponibile() { return this.zborService.getZboruriDisponibile(); }

        public void modifZborBilet(Zbor zbor, int nrBilete)
        {
            nrBilete = zbor.NrLocuriLibere - nrBilete;
            this.zborService.modifZborBilet(zbor, nrBilete);
        }

        public void addBilet(String numeClient, String numeTuristi, String adresa, int nrBilete, int ID)
        {
            Zbor zbor = this.zborService.getZborbyID(ID);
            this.biletService.addBilet(numeClient, numeTuristi, adresa, nrBilete, zbor);
            this.modifZborBilet(zbor, nrBilete);
        }
    }
}