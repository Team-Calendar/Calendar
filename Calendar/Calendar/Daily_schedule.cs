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
            string connectionString = "Data Source=DESKTOP-L2ESCEA\\MSSQLSERVER01;Initial Catalog=Calendar;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Chose what date you want to see your schedule ?");
                string a = Console.ReadLine();
                DateTime enterDate = DateTime.MinValue;

                if (!DateTime.TryParse(a, out enterDate))
                {
                    Console.WriteLine("Please enter valid date");
                    Schedule();
                    // TODO: Invalid input for enterDate
                }

                connection.Open();

                string query = "SELECT * FROM Events WHERE start_time = @EnterDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EnterDate", enterDate);

                // 22:37

                DateTime.Now.Date.AddHours(22).AddMinutes(37);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID:{reader[0]}\tname:{reader[1]}\tstart_time:{reader[2]}\tend_time:{reader[3]}\tplace:{reader[4]}\tcomment:{reader[5]}");
                }
            }

        }

    }
}
