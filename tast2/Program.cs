using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System.Net;
using MySql.Data.MySqlClient;


namespace tast2
{
    internal class Program
    {
        
        static void Main(string[] args)
            
        {
            string connectionString = "server=127.0.0.1;port=3306;username=root;password=;database=tesquest";
            string query = "SELECT IP, sity, state FROM geo_us";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabse =new MySqlCommand(query, databaseConnection);
            commandDatabse.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabse.ExecuteReader();
                while (reader.Read()) 
                { 
                    string ip = reader.GetString("ip");
                    string sity = reader.GetString("sity");
                    string state = reader.GetString("state");
                    string[] parts = ip.Split('/');
                    string mask = (parts.Length > 1) ? parts[1] : "";
                    Console.WriteLine($"{mask}\t{sity}\t{state}");
                }


                databaseConnection.Close();
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            
            
        }
    }
}