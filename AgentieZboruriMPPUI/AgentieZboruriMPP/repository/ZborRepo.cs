using AgentieZboruriMPP.domain;
using System.Data;
using log4net;
using Serilog;
using System.Collections.Generic;
using System;

namespace AgentieZboruriMPP.repository
{
    public class ZborRepo : IRepoZbor
    {
        IDictionary<String, string> Props;

        public ZborRepo(IDictionary<String, string> props)
        {
            Log.Information("Creating ZborRepo");
            this.Props = props;
        }

        public List<Zbor> getAll()
        {
            IDbConnection con = DBUtils.getConnection(Props);
            List<Zbor> zborList = new List<Zbor>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT * FROM Zbor";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idZ = dataR.GetInt32(0);
                        String destinatie = dataR.GetString(1);
                        String data = dataR.GetString(2);
                        String ora = dataR.GetString(3);
                        String airport = dataR.GetString(4);
                        int nrLocuriLibere = dataR.GetInt32(5);

                        DateTime oDate = Convert.ToDateTime(data);

                        Zbor zbor = new Zbor(idZ, destinatie, oDate, ora, airport, nrLocuriLibere);
                        zborList.Add(zbor);
                    }
                }
            }
            return zborList;
        }

        public Zbor getById(long entityId)
        {
            Log.Information("Entering findOne with value {0}", entityId);
            IDbConnection con = DBUtils.getConnection(Props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Zbor where idZ = @id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entityId;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idZ = dataR.GetInt32(0);
                        String destinatie = dataR.GetString(1);
                        String data = dataR.GetString(2);
                        String ora = dataR.GetString(3);
                        String airport = dataR.GetString(4);
                        int nrLocuriLibere = dataR.GetInt32(5);

                        DateTime oDate = Convert.ToDateTime(data);

                        Zbor zbor = new Zbor(idZ, destinatie, oDate, ora, airport, nrLocuriLibere);
                        Log.Information("Zbor found.");
                        return zbor;
                    }
                }
            }
            Log.Information("Zbor not found.");
            return null;
        }

        public void update(Zbor updateEntity)
        {
            var con = DBUtils.getConnection(Props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Zbor set destinatie = @destinatie, data = @data, ora = @ora, airport = @airport, nrLocuriLibere = @nrLocuriLibere where idZ = @idz";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@idz";
                paramId.Value = updateEntity.getId();
                comm.Parameters.Add(paramId);

                var paramDest = comm.CreateParameter();
                paramDest.ParameterName = "@destinatie";
                paramDest.Value = updateEntity.Destination;
                comm.Parameters.Add(paramDest);

                var paramData = comm.CreateParameter();
                paramData.ParameterName = "@data";
                paramData.Value = updateEntity.Data;
                comm.Parameters.Add(paramData);

                var paramOra = comm.CreateParameter();
                paramOra.ParameterName = "@ora";
                paramOra.Value = updateEntity.Time;
                comm.Parameters.Add(paramOra);

                var paramNrLibere = comm.CreateParameter();
                paramNrLibere.ParameterName = "@nrLocuriLibere";
                paramNrLibere.Value = updateEntity.NrLocuriLibere;
                comm.Parameters.Add(paramNrLibere);

                var paramAirport = comm.CreateParameter();
                paramAirport.ParameterName = "@airport";
                paramAirport.Value = updateEntity.Airport;
                comm.Parameters.Add(paramAirport);

                var result = comm.ExecuteNonQuery();

                if (result == 0)
                {
                    Log.Information("No zbor update");
                    throw new Exception("No zbor update!");
                }
            }
            Log.Information("Zbor update");
        }

        public void insert(Zbor newEntity)
        {
            var con = DBUtils.getConnection(Props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Zbor  values (@idZ, @destinatie, @data, @ora, @airport, @nrLocuriLibere)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@idZ";
                paramId.Value = newEntity.getId();
                comm.Parameters.Add(paramId);

                var paramDest = comm.CreateParameter();
                paramDest.ParameterName = "@destinatie";
                paramDest.Value = newEntity.Destination;
                comm.Parameters.Add(paramDest);

                var paramData = comm.CreateParameter();
                paramData.ParameterName = "@data";
                paramData.Value = newEntity.Data;
                comm.Parameters.Add(paramData);

                var paramOra = comm.CreateParameter();
                paramOra.ParameterName = "@ora";
                paramOra.Value = newEntity.Time;
                comm.Parameters.Add(paramOra);

                var paramNrLibere = comm.CreateParameter();
                paramNrLibere.ParameterName = "@airport";
                paramNrLibere.Value = newEntity.Airport;
                comm.Parameters.Add(paramNrLibere);

                var paramAirport = comm.CreateParameter();
                paramAirport.ParameterName = "@nrLocuriLibere";
                paramAirport.Value = newEntity.NrLocuriLibere;
                comm.Parameters.Add(paramAirport);

                var result = comm.ExecuteNonQuery();

                if (result == 0)
                {
                    Log.Information("No zbor added");
                    throw new Exception("No zbor added!");
                }
                Log.Information("Zbor added");
            }
        }

        public void delete(Zbor deleteEntity)
        {
            IDbConnection con = DBUtils.getConnection(Props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Zbor where idZ=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = deleteEntity.getId();
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                {
                    Log.Information("No zbor deleted");
                    throw new Exception("No zbor deleted!");
                }

                Log.Information("Zbor deleted");
            }
        }

        public List<Zbor> getZborbySearch(String destination, DateTime date)
        {
            IDbConnection con = DBUtils.getConnection(Props);
            List<Zbor> zborList = new List<Zbor>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT * FROM Zbor where destinatie = @destination and data = @data and nrLocuriLibere != 0";
                Console.WriteLine("ad");
                IDbDataParameter paramDest = comm.CreateParameter();
                paramDest.ParameterName = "@destination";
                paramDest.Value = destination;
                comm.Parameters.Add(paramDest);

                IDbDataParameter paramData = comm.CreateParameter();
                paramData.ParameterName = "@data";
                paramData.Value = date;
                comm.Parameters.Add(paramData);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idZ = dataR.GetInt32(0);
                        String destinatie = dataR.GetString(1);
                        String data = dataR.GetString(2);
                        String ora = dataR.GetString(3);
                        String airport = dataR.GetString(4);
                        int nrLocuriLibere = dataR.GetInt32(5);

                        DateTime oDate = Convert.ToDateTime(data);

                        Zbor zbor = new Zbor(idZ, destinatie, oDate, ora, airport, nrLocuriLibere);
                        zborList.Add(zbor);
                    }
                }
            }
            return zborList;
        }

        public List<String> getDestinations()
        {
            IDbConnection con = DBUtils.getConnection(Props);
            List<String> lst = new List<String>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT * FROM Zbor";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        String destinatie = dataR.GetString(1);
                        lst.Add(destinatie);
                    }
                }
            }

            return lst;
        }

        public List<Zbor> getZboruriDisponibile()
        {
            IDbConnection con = DBUtils.getConnection(Props);
            List<Zbor> zborList = new List<Zbor>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT * FROM Zbor where nrLocuriLibere != 0";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idZ = dataR.GetInt32(0);
                        String destinatie = dataR.GetString(1);
                        String data = dataR.GetString(2);
                        String ora = dataR.GetString(3);
                        String airport = dataR.GetString(4);
                        int nrLocuriLibere = dataR.GetInt32(5);

                        DateTime oDate = Convert.ToDateTime(data);

                        Zbor zbor = new Zbor(idZ, destinatie, oDate, ora, airport, nrLocuriLibere);
                        zborList.Add(zbor);
                    }
                }
            }
            return zborList;
        }

        public void modifZborBilet(Zbor zbor, int nrBilete)
        {
            var con = DBUtils.getConnection(Props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Zbor set nrLocuriLibere = @nrLocuriLibere where idZ = @idz";

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@idz";
                paramId.Value = zbor.getId();
                comm.Parameters.Add(paramId);

                var paramNr = comm.CreateParameter();
                paramNr.ParameterName = "@nrLocuriLibere";
                paramNr.Value = nrBilete;
                comm.Parameters.Add(paramNr);

                var result = comm.ExecuteNonQuery();

                if (result == 0)
                {
                    Log.Information("No zbor update");
                    throw new Exception("No zbor update!");
                }
            }
            Log.Information("Zbor update");
        }
    }
}