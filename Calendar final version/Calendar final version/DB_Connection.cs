using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_final_version
{
    class DB_Connection
    {
        public void InsertThem()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CalendarDB;Trusted_Connection=True;";

            Console.WriteLine("1.Create Event");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var TextValue = Console.ReadLine();
                connection.Open();
                var command =
                    new SqlCommand("INSERT INTO Events (name) VALUES (@textValue);", connection);
                command.Parameters.AddWithValue("@textValue", TextValue);
                command.ExecuteNonQuery();
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Events";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID:{reader[0]}\tName:{reader[1]}");
                }

            }


        }

        public void SelectEvent()
        {

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CalendarDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Events";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID:{reader[0]}\tName:{reader[1]}\tStart_time:{reader[2]}\tEnd_time:{reader[3]}\tPlace:{reader[4]}\tComment:{reader[5]}:");
                }

            }
        }


        public void Delete()
        {

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CalendarDB;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Chose what date you want to Edit or Cancel ?");
                string a = Console.ReadLine();
                int placeId = Int32.Parse(a);

                //if (!DateTime.TryParse(a, out enterDate))
                //{
                //    Console.WriteLine("Please enter valid date");
                //    Delete();
                //    // TODO: Invalid input for enterDate
                //}
                Console.WriteLine("Do you want to 1 - Cancel or 2 - Edit the event ?");
                int choise = Int32.Parse(Console.ReadLine());
                if (choise == 1)
                {
                    connection.Open();
                    string query = "DELETE FROM EVENTS WHERE place_id = @placeId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@placeId", placeId);
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("You canceled the event succsessfully!");

                }

                if (choise == 2)
                {
                    Console.WriteLine("Enter your new event name!");
                    var newName = Console.ReadLine();
                    DateTime startTime = DateTime.Parse(Console.ReadLine());
                    DateTime endTime = DateTime.Parse(Console.ReadLine());
                    connection.Open();
                    string query = "UPDATE Events SET (name, star_time, end_time) = (@NewName, @startTime, @endTime) WHERE place_id = @placeId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@enterDate", placeId);
                        command.Parameters.AddWithValue("@NewName", newName);
                        command.Parameters.AddWithValue("@startTime", startTime);
                        command.Parameters.AddWithValue("@endTime", endTime);

                        command.ExecuteNonQuery();
                    }

                }
            }
        }

    }
}
