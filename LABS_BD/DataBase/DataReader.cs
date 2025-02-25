using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABS_BD.DataBase
{
    public class DataReader
    {
        public string connectionString { get; private set; }
        private static DataReader instance;
        private readonly string filePath = @"C:\Users\trokh\source\repos\LABS_BD\LABS_BD\DataBase\Config.json";
        private DataReader()
        {
            string json = File.ReadAllText(filePath);
            var config = System.Text.Json.JsonSerializer.Deserialize<ConnectTODB>(json);
            if (string.IsNullOrEmpty(config.Host) || string.IsNullOrEmpty(config.Port) ||
                string.IsNullOrEmpty(config.Username) || string.IsNullOrEmpty(config.Password) ||
                string.IsNullOrEmpty(config.Database))
            {
                throw new ArgumentException("One or more connection parameters are missing in the config file.");
            }
            connectionString = $"Host={config.Host};Port={config.Port};Username={config.Username};Password={config.Password};Database={config.Database}";
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
