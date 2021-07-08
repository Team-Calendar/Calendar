using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{

    class Create_Event
    {

        public void InsertThem()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CalendarDB;Trusted_Connection=True;";

            Console.WriteLine("1.Create Event");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Type the event name.");
                var TextValue = Console.ReadLine();
                Console.WriteLine("Type the event start time and date.");
                DateTime Start_time = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Type the event end_time and date.");
                DateTime End_time = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Type the event place.");
                var Place = Console.ReadLine();
                Console.WriteLine("Type event comment.");
                var Comment = Console.ReadLine();       
                connection.Open();

                var command =
                    new SqlCommand("INSERT INTO Events (name,start_time,end_time,place,comment) VALUES (@textValue,@Start_time,@End_time,@Place,@Comment);", connection);
                command.Parameters.AddWithValue("@textValue", TextValue);
                command.Parameters.AddWithValue("@Start_time", Start_time);
                command.Parameters.AddWithValue("@End_time", End_time);
                command.Parameters.AddWithValue("@Place", Place);
                command.Parameters.AddWithValue("@Comment", Comment);
                command.ExecuteNonQuery();
                Console.WriteLine("You succsessfully added new Event!");
            }

        


        }

    }
}