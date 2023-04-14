
using System;

namespace AgentieZboruriMPP.domain
{
    public class Zbor : Entity<long>
    {
        public long ID { get; set; }
        public string Destination { get; set; }
        public DateTime Data { get; set; }
        public string Time { get; set; }
        public string Airport { get; set; }
        public int NrLocuriLibere { get; set; }

        public Zbor(long id, string destination, DateTime data, string time, string airport, int nrLocuriLibere) : base(id)
        {
            this.ID = id;
            this.Destination = destination;
            this.Data = data;
            this.Time = time;
            this.Airport = airport;
            this.NrLocuriLibere = nrLocuriLibere;
        }

        public override string ToString()
        {
            return "Zbor{" +
                   "destination='" + Destination + '\'' +
                   ", data=" + Data +
                   ", time=" + Time +
                   ", airport='" + Airport + '\'' +
                   ", nrLocuriLibere=" + NrLocuriLibere +
                   '}';
        }
    }
}