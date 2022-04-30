using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.Models.DB
{
    public class ConfigurationDB
    {
        public static string ConnectionString => "data source = " + Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"Data\ToDoDB.db"));
    }
}
