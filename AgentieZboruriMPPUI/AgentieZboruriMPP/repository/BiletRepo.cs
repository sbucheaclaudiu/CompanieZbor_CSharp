using AgentieZboruriMPP.domain;
using System;
using System.Data;
using log4net;
using Serilog;
using System.Collections.Generic;

namespace AgentieZboruriMPP.repository
{
    public class BiletRepo : IRepoBilet
    {
        IDictionary<String, string> Props;

        public BiletRepo(IDictionary<String, string> props)
        {
            Log.Information("Creating BiletRepo");
            Props = props;
        }

        public List<Bilet> getAll()
        {
            IDbConnection con = DBUtils.getConnection(Props);
            List<Bilet> biletList = new List<Bilet>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Bilet INNER JOIN Zbor ON Bilet.zbor_id = Zbor.idZ";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String numeClient = dataR.GetString(1);
                        String numeTuristi = dataR.GetString(2);
                        String adresa = dataR.GetString(3);
                        int nrLocuri = dataR.GetInt16(4);

                        int idZ = dataR.GetInt32(5);
                        String destinatie = dataR.GetString(7);
                        String data = dataR.GetString(8);
                        String ora = dataR.GetString(9);
                        String airport = dataR.GetString(10);
                        int nrLocuriLibere = dataR.GetInt32(11);

                        DateTime oDate = Convert.ToDateTime(data);

                        Zbor zbor = new Zbor(idZ, destinatie, oDate, ora, airport, nrLocuriLibere);
                        Bilet bilet = new Bilet(id, numeClient, numeTuristi, adresa, nrLocuri, zbor);
                        biletList.Add(bilet);
                    }
                }
            }
            return biletList;
        }

        public Bilet getById(long entityId)
        {
            Log.Information("Entering findOne with value {0}", entityId);
            IDbConnection con = DBUtils.getConnection(Props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Bilet INNER JOIN Zbor ON Bilet.zbor_id = Zbor.idZ where id = @id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entityId;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String numeClient = dataR.GetString(1);
                        String numeTuristi = dataR.GetString(2);
                        String adresa = dataR.GetString(3);
                        int nrLocuri = dataR.GetInt32(4);

                        int idZ = dataR.GetInt32(5);
                        String destinatie = dataR.GetString(7);
                        String data = dataR.GetString(8);
                        String ora = dataR.GetString(9);
                        String airport = dataR.GetString(10);
                        int nrLocuriLibere = dataR.GetInt32(11);

                        DateTime oDate = Convert.ToDateTime(data);

                        Zbor zbor = new Zbor(idZ, destinatie, oDate, ora, airport, nrLocuriLibere);
                        Bilet bilet = new Bilet(id, numeClient, numeTuristi, adresa, nrLocuri, zbor);
                        Log.Information("Bilet found.");
                        return bilet;
                    }
                }
            }
            Log.Information("Bilet not found.");
            return null;
        }

        public void update(Bilet updateEntity)
        {
            var con = DBUtils.getConnection(Props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Bilet set numeClient = @numeClient, numeTuristi = @numeTuristi, adresa = @adresa, nrLocuri = @nrLocuri, zbor_id = @zbor_id where id = @id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = updateEntity.getId();
                comm.Parameters.Add(paramId);

                var paramClient = comm.CreateParameter();
                paramClient.ParameterName = "@numeClient";
                paramClient.Value = updateEntity.NumeClient;
                comm.Parameters.Add(paramClient);

                var paramData = comm.CreateParameter();
                paramData.ParameterName = "@numeTuristi";
                paramData.Value = updateEntity.NumeTuristi;
                comm.Parameters.Add(paramData);

                var paramOra = comm.CreateParameter();
                paramOra.ParameterName = "@adresa";
                paramOra.Value = updateEntity.Adresa;
                comm.Parameters.Add(paramOra);

                var paramNrLibere = comm.CreateParameter();
                paramNrLibere.ParameterName = "@nrLocuri";
                paramNrLibere.Value = updateEntity.NrLocuri;
                comm.Parameters.Add(paramNrLibere);

                var paramZbor = comm.CreateParameter();
                paramZbor.ParameterName = "@zbor_id";
                paramZbor.Value = updateEntity.Zbor.getId();
                comm.Parameters.Add(paramZbor);

                var result = comm.ExecuteNonQuery();

                if (result == 0)
                {
                    Log.Information("No Bilet update");
                    throw new Exception("No bilet update!");
                }
                Log.Information("Bilet update");
            }
        }

        public void insert(Bilet newEntity)
        {
            var con = DBUtils.getConnection(Props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText =
                    "insert into Bilet  values (@id, @numeClient, @numeTuristi, @adresa, @nrLocuri, @zbor_id)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = newEntity.getId();
                comm.Parameters.Add(paramId);

                var paramClient = comm.CreateParameter();
                paramClient.ParameterName = "@numeClient";
                paramClient.Value = newEntity.NumeClient;
                comm.Parameters.Add(paramClient);

                var paramData = comm.CreateParameter();
                paramData.ParameterName = "@numeTuristi";
                paramData.Value = newEntity.NumeTuristi;
                comm.Parameters.Add(paramData);

                var paramOra = comm.CreateParameter();
                paramOra.ParameterName = "@adresa";
                paramOra.Value = newEntity.Adresa;
                comm.Parameters.Add(paramOra);

                var paramNrLibere = comm.CreateParameter();
                paramNrLibere.ParameterName = "@nrLocuri";
                paramNrLibere.Value = newEntity.NrLocuri;
                comm.Parameters.Add(paramNrLibere);

                var paramZbor = comm.CreateParameter();
                paramZbor.ParameterName = "@zbor_id";
                paramZbor.Value = newEntity.Zbor.getId();
                comm.Parameters.Add(paramZbor);

                var result = comm.ExecuteNonQuery();

                if (result == 0)
                {
                    Log.Information("No bilet added");
                    throw new Exception("No bilet added!");
                }
                Log.Information("Bilet added");
            }
        }

        public void delete(Bilet deleteEntity)
        {
            IDbConnection con = DBUtils.getConnection(Props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Bilet where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = deleteEntity.getId();
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                {
                    Log.Information("No bilet deleted");
                    throw new Exception("No bilet deleted!");
                }

                Log.Information("Bilet deleted");
            }
        }
    }
}