namespace AgentieZboruriMPP.domain
{
    public class Bilet : Entity<long>
    {
        public string NumeClient { get; set; }
        public string NumeTuristi { get; set; }
        public string Adresa { get; set; }
        public int NrLocuri { get; set; }
        public Zbor Zbor { get; set; }

        public Bilet(long id, string numeClient, string numeTuristi, string adresa, int nrLocuri, Zbor zbor) : base(id)
        {
            this.NumeClient = numeClient;
            this.NumeTuristi = numeTuristi;
            this.Adresa = adresa;
            this.NrLocuri = nrLocuri;
            this.Zbor = zbor;
        }

        public override string ToString()
        {
            return "Bilet{" +
                   "numeClient='" + NumeClient + '\'' +
                   ", numeTuristi='" + NumeTuristi + '\'' +
                   ", adresa='" + Adresa + '\'' +
                   ", nrLocuri=" + NrLocuri +
                   ", zbor=" + Zbor +
                   '}';
        }
    }
}