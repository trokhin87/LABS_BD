using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students_prepods.DataBase
{
    public class DataReader
    {
        public string connectionStringJunior { get; private set; }
        public string connectionStringAdmin { get; private set; }

        private static DataReader instance;
        private readonly string filePath = @"C:\Users\trokh\source\repos\LABS_BD\students_prepods\DataBase\Config.json";
        private DataReader()
        {
            string json = File.ReadAllText(filePath);
            var config = System.Text.Json.JsonSerializer.Deserialize<ConnectTODB>(json);
            if (string.IsNullOrEmpty(config.Host) || string.IsNullOrEmpty(config.Port) ||
                string.IsNullOrEmpty(config.Username_junior) || string.IsNullOrEmpty(config.Password_junior) ||
                string.IsNullOrEmpty(config.Username_admin) || string.IsNullOrEmpty(config.Password_admin) ||
                string.IsNullOrEmpty(config.Database))
            {
                throw new ArgumentException("One or more connection parameters are missing in the config file.");
            }
            connectionStringJunior = $"Host={config.Host};Port={config.Port};Username={config.Username_junior};Password={config.Password_junior};Database={config.Database}";
            connectionStringAdmin = $"Host={config.Host};Port={config.Port};Username={config.Username_admin};Password={config.Password_admin};Database={config.Database}";
        }
        public static DataReader Instance()
        {
            if (instance == null)
            {
                instance = new DataReader();
            }
            return instance;
        }
    }
}
