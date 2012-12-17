namespace BusTerminalMonitoringServerApp.Database
{
    using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;

    public class BusDBContext : IDisposable
    {
        private MySqlConnection connection = default(MySqlConnection);
        /// <summary>
        /// Constructor
        /// Instanciate MySqlConnection with connection from App.Config "ConnectionString"
        /// </summary>
        public BusDBContext()
        {
            this.connection = new MySqlConnection(ConfigurationManager.AppSettings.Get("ConnectionString"));
        }
        public List<Bus> Select(string bus_number)
        {
            /// Initialize results with default(List<Bus>) or Null
            List<Bus> results = default(List<Bus>);
            if (!string.IsNullOrEmpty(bus_number))
            {
                this.connection.Open();
                string select_command = string.Format("SELECT * FROM tbl_bus where bus_number='{0}'", bus_number);
                using (MySqlCommand command = new MySqlCommand(select_command, this.connection))
                {
                    
                }
                this.connection.Close();
            }
            return results;
        }
        /// <summary>
        /// Close MySqlConnection and Dispose
        /// </summary>
        public void Dispose()
        {
            this.connection.Close();
            this.connection.Dispose();
        }
    }
}
