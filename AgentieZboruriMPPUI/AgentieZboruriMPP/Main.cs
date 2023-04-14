using AgentieZboruriMPP.repository;
using AppKit;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices;
using AgentieZboruriMPP.domain;
using AgentieZboruriMPP.service;


namespace AgentieZboruriMPP
{
	static class MainClass
	{
        static string GetConnectionStringByName(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        static void Main(string[] args)
        {
	        Log.Logger = new LoggerConfiguration().WriteTo.File("/log_net.txt").CreateLogger();

	        //db connect: trb adaugat in references sqlite, mono...
	        IDictionary<string, string> props = new SortedList<string, string>();
	        var connectionString = GetConnectionStringByName("AgentieZboruriDB");
	        props.Add("ConnectionString", connectionString);

	        var userRepo = new UserRepo(props);
	        var zborRepo = new ZborRepo(props);
	        var biletRepo = new BiletRepo(props);

	        BiletService biletService = new BiletService(biletRepo);
	        UserService userService = new UserService(userRepo);
	        ZborService zborService = new ZborService(zborRepo);

	        ServiceMain service = new ServiceMain(userService, zborService, biletService);

	        Helper.UserService = userService;
	        Helper.BiletService = biletService;
	        Helper.ZborService = zborService;

	        Log.CloseAndFlush();

            NSApplication.Init ();
			NSApplication.Main(args);
			
		}
	}
}
