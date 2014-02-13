using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Slacker
{
    class MySQLStorage : IStorage
    {

        private ISettings _settings;
        private MySqlConnection _connection;

        public MySQLStorage()
        {
            _settings = new Settings();
            initialise();
        }


        public void initialise()
        {
            string server = _settings.get("DATABASE", "HOST", "development");
            string database = _settings.get("DATABASE", "DATABASE", "glynntucker");
            string uid = _settings.get("DATABASE", "USER", "anonymous");
            string password = _settings.get("DATABASE", "PASSWORD", "");
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            Console.WriteLine(connectionString);
            _connection = new MySqlConnection(connectionString);
            openConnection();
        }


        private bool openConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                return true;
            }

            bool success = false;
            try
            {
                _connection.Open();
                success = true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid Credentials");
                        break;
                }
            }
            return success;
        }

        public bool isReady()
        {
            return this.openConnection();
        }

        public void insert(List<TimeEntry> times)
        {
            if (openConnection())
            {                
                for (int i = 0; i < times.Count; i++){
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO times (job_id, employee_id, date, hours, task, details) VALUES (?job, ?emp, ?date, ?hrs, ?task, ?details)", _connection);

                    TimeEntry t = times[i];
                    cmd.Parameters.AddWithValue("?job", t.jobId);
                    cmd.Parameters.AddWithValue("?emp", TimeEntry.Employee);
                    cmd.Parameters.AddWithValue("?date", t.day.Date);
                    cmd.Parameters.AddWithValue("?hrs", t.hours);
                    cmd.Parameters.AddWithValue("?task", TimeEntry.DefaultTaskType);
                    cmd.Parameters.AddWithValue("?details", t.description);
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }
            }
            
        }
    }
}
