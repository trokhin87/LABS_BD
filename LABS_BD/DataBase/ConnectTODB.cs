using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LABS_BD.DataBase
{
    public class ConnectTODB
    {
        [JsonProperty("Host")]
        public string? Host { get; set; }

        [JsonProperty("Port")]
        public string? Port { get; set; }

        [JsonProperty("Username")]
        public string? Username { get; set; }

        [JsonProperty("Password")]
        public string? Password { get; set; }

        [JsonProperty("Database")]
        public string? Database { get; set; }
    }
}
