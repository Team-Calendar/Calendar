using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class Daily_schedule
    {
        public void Schedule()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CalendarDB;Trusted_Connection=True;";
       
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Chose what date you want to see your schedule ?");
                DateTime EnterDate = DateTime.Parse(Console.ReadLine());
              
                connection.Open();

                string query = "SELECT * FROM Events WHERE start_time =@EnterDate";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID:{reader[0]}\tname:{reader[1]}\tstart_time:{reader[2]}\tend_time:{reader[3]}\tplace:{reader[4]}\tcomment:{reader[5]}");
                }

                using (SqlCommand command2 = new SqlCommand(query, connection))
                {
                    command2.Parameters.AddWithValue("@EnterDate", EnterDate);
                    command.ExecuteNonQuery();
                }
            }

        }

    }
}
