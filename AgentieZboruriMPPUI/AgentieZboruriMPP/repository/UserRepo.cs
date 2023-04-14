using AgentieZboruriMPP.domain;
using System.Data;
using log4net;
using Serilog;
using System;
using System.Collections.Generic;

namespace AgentieZboruriMPP.repository
{
    public class UserRepo : IRepoUser
    {
        IDictionary<String, string> Props;

        public UserRepo(IDictionary<String, string> props)
        {
            Log.Information("Creating UserRepo");
            this.Props = props;
        }

        public List<User> getAll()
        {
            IDbConnection con = DBUtils.getConnection(Props);
            List<User> userList = new List<User>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "SELECT * FROM User";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        String username = dataR.GetString(0);
                        String password = dataR.GetString(1);
                        User user = new User(username, password);
                        userList.Add(user);
                    }
                }
            }
            return userList;
        }

        public User getById(string entityId)
        {
            Log.Information("Entering findOne with value {0}", entityId);
            IDbConnection con = DBUtils.getConnection(Props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from User where username = @username";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@username";
                paramId.Value = entityId;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        String username = dataR.GetString(0);
                        String password = dataR.GetString(1);
                        User user = new User(username, password);
                        Log.Information("User found.");
                        return user;
                    }
                }
            }
            Log.Information("User not found.");
            return null;
        }

        public void update(User updateEntity)
        {
            var con = DBUtils.getConnection(Props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update User set password = @password where username = @username";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@username";
                paramId.Value = updateEntity.Username;
                comm.Parameters.Add(paramId);

                var paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@password";
                paramPass.Value = updateEntity.Password;
                comm.Parameters.Add(paramPass);

                var result = comm.ExecuteNonQuery();

                if (result == 0)
                {
                    Log.Information("User not update.");
                    throw new Exception("No user update!");
                }
            }

            Log.Information("User update.");
        }

        public void insert(User newEntity)
        {
            var con = DBUtils.getConnection(Props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into User(username, password) values (@username, @password)";

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@username";
                paramId.Value = newEntity.Username;
                comm.Parameters.Add(paramId);

                var paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@password";
                paramPass.Value = newEntity.Password;
                comm.Parameters.Add(paramPass);

                var result = comm.ExecuteNonQuery();

                if (result == 0)
                {
                    Log.Information("No user added");
                    throw new Exception("No user added!");
                }

                Log.Information("User added");
            }

        }

        public void delete(User deleteEntity)
        {
            IDbConnection con = DBUtils.getConnection(Props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from User where username=@username";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@username";
                paramId.Value = deleteEntity.Username;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();

                if (dataR == 0)
                {
                    Log.Information("No user deleted");
                    throw new Exception("No user deleted!");
                }

                Log.Information("User deleted");
            }
        }

        public User findUser(String username, String password)
        {
            IDbConnection con = DBUtils.getConnection(Props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from User where username = @username and password = @password";
                IDbDataParameter paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = username;
                comm.Parameters.Add(paramUsername);

                IDbDataParameter paramPassword = comm.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = password;
                comm.Parameters.Add(paramPassword);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        String username2 = dataR.GetString(0);
                        String password2 = dataR.GetString(1);
                        User user = new User(username2, password2);
                        Log.Information("User found.");
                        return user;
                    }
                }
            }
            Log.Information("User not found.");
            return null;
        }
    }
}