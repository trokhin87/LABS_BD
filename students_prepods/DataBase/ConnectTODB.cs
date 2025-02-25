using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace students_prepods.DataBase                                          
{
    public class ConnectTODB
    {
        [JsonProperty("Host")]
        public string? Host { get; set; }

        [JsonProperty("Port")]
        public string? Port { get; set; }

        [JsonProperty("Username_junior")]
        public string? Username_junior { get; set; }

        [JsonProperty("Username_admin")]
        public string? Username_admin { get; set; }

        [JsonProperty("Password_junior")]
        public string? Password_junior { get; set; }

        [JsonProperty("Password_admin")]
        public string? Password_admin { get; set; }

        [JsonProperty("Database")]
        public string? Database { get; set; }
    }
}
