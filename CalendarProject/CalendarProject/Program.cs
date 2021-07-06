using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost\\MSSQLSERVER01;Database=CalendarDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Place";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader[0]}\tName: {reader[1]}\tAddress {reader[2]}:");
                }

                string query1 = "SELECT * FROM Event";
                SqlCommand command1 = new SqlCommand(query, connection);
                SqlDataReader reader1 = command.ExecuteReader();

            }

        }
        private static void CreateCommand(string queryString,
        string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }


    }
}
