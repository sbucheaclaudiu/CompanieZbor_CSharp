using System.Configuration;
using AgentieZboruri_lab02MPP.domain;
using AgentieZboruri_lab02MPP.repository;
using Mono.Data.Sqlite;
using log4net;
using log4net.Config;
using Serilog;

static string GetConnectionStringByName(string name)
{
    return ConfigurationManager.ConnectionStrings[name].ConnectionString;
}

static void teste(IDictionary<string, string> props)
{
    var userRepo = new UserRepo(props);
    var zborRepo = new ZborRepo(props);
    var biletRepo = new BiletRepo(props);
    
    //foreach (var t in userRepo.getAll()) Console.WriteLine(t);
    //foreach (var t in zborRepo.getAll()) Console.WriteLine(t);
    //foreach (var t in biletRepo.getAll()) Console.WriteLine(t);
    
    User user = userRepo.getById("user1");
    Zbor zbor = zborRepo.getById(1);
    Bilet bilet = biletRepo.getById(1);
    
    User user1 = new User("username12", "password");
    userRepo.insert(user1);

    DateTime date = new DateTime(2002, 10, 21);
    Zbor zbor1 = new Zbor(1200,"Paris",date, "13:49", "Air",238);
    zborRepo.insert(zbor1);

    Bilet bilet1 = new Bilet(1200, "test", "test", "test", 2, zbor);
    biletRepo.insert(bilet1);

    biletRepo.update(new Bilet(1200L, "aa", "aa", "aaaaaa", 2, zbor));
    zborRepo.update(new Zbor(1200L,"Parissss",date,"10:59", "Ai3r",238));
    userRepo.update(new User("username12", "pass"));
    
    userRepo.delete(user1);
    biletRepo.delete(bilet1);
    zborRepo.delete(zbor1);
}

Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("/log_net.txt").CreateLogger();

IDictionary<string, string> props = new SortedList<string, string>();
var connectionString = GetConnectionStringByName("AgentieZboruriDB");
props.Add("ConnectionString", connectionString);

Log.Information("ddsdsds");

var userRepo = new UserRepo(props);
var zborRepo = new ZborRepo(props);
var biletRepo = new BiletRepo(props);

teste(props);

Log.CloseAndFlush();

