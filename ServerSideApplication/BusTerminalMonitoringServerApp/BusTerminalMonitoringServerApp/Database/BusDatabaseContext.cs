namespace BusTerminalMonitoringServerApp.Database
{
    using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;

    public class BusDatabaseContext : IDisposable
    {
        private MySqlConnection connection = default(MySqlConnection);
        /// <summary>
        /// Constructor
        /// Instanciate MySqlConnection with connection from App.Config "ConnectionString"
        /// </summary>
        public BusDatabaseContext()
        {
            this.connection = new MySqlConnection(ConfigurationManager.AppSettings.Get("ConnectionString"));
            /// Open connection instance
            this.connection.Open();
        }
        /// <summary>
        /// Select Query Statement 
        /// </summary>
        /// <param name="bus_number"></param>
        /// <returns></returns>
        public List<Bus> Select(string bus_number)
        {
            /// Initialize results with default(List<Bus>) or Null
            List<Bus> results = default(List<Bus>);
            if (!string.IsNullOrEmpty(bus_number))
            {
                string select_command = string.Format("SELECT * FROM tbl_bus where bus_number='{0}'", bus_number);
                using (MySqlCommand command = new MySqlCommand(select_command, this.connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new Bus
                            {
                                BusNumber = reader["bus_number"].ToString(),
                                Capacity = reader["bus_capacity"].ToString(),
                                Details = reader["bus_details"].ToString(),
                                Lattitude = reader["bus_lattitude"].ToString(),
                                Longitude = reader["bus_longitude"].ToString(),
                                Occupied = reader["bus_occupied"].ToString(),
                                Vacancy = reader["bus_vacant"].ToString()
                            });
                        }
                    }
                }
            }
            return results;
        }
        /// <summary>
        /// Update record base on Bus Instance
        /// </summary>
        /// <param name="bus"></param>
        public void Update(Bus bus)
        {
            if (bus != null)
            {
                string update_statement = string.Format("UPDATE tbl_bus SET bus_lattitude='{1}', bus_longitude='{2}', bus_vacant={3}, bus_occupied={4} WHERE bus_number='{0}'"
                    , bus.BusNumber
                    , bus.Lattitude
                    , bus.Longitude
                    , bus.Vacancy
                    , bus.Occupied);
                using (MySqlCommand command = new MySqlCommand(update_statement, this.connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
        }
        /// <summary>
        /// Insert new Bus instance in database
        /// </summary>
        /// <param name="bus"></param>
        public void Insert(Bus bus)
        {
            if (bus != null)
            {
                string insert_statement = string.Format("INSERT INTO tbl_bus (bus_number, bus_capacity, bus_details, bus_lattitude, bus_longitude, bus_occupied, bus_vacant) VALUES('{0}',{1},'{2}','{3}','{4}',{5},{6})"
                    , bus.BusNumber
                    , bus.Capacity
                    , bus.Details
                    , bus.Lattitude
                    , bus.Longitude
                    , bus.Occupied
                    , bus.Vacancy);
                using (MySqlCommand command = new MySqlCommand(insert_statement, this.connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
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
