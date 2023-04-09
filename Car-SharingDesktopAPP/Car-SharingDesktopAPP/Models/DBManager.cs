using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_SharingDesktopAPP
{
    class DBManager
    {
        private static object connectionString;

        public static object GetConnectionString()
        {
            string json = File.ReadAllText("./db.json");
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            if(data.TryGetValue("ConnectionString", out connectionString))
                return connectionString;

            throw new Exception("ConnectionString not found in JSON file");
        }
    }
}
