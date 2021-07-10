using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_final_version
{
    class DB_Connection

    {

        public string TextValue { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public string Place { get; set; }
        public string Comment { get; set; }




        public DB_Connection(string T, DateTime D, DateTime S, DateTime E, string P, string C)
        {
            this.TextValue = T;
            this.Date = D;
            this.Start_Time = S;
            this.End_Time = E;
            this.Place = P;
            this.Comment = C;
        }

        public DB_Connection()
        {
            this.TextValue = "Nothing";

        }
        public void CreateEvent()
        {
            //DateTime MaxTime = new DateTime(8,00,00);
            //DateTime MaxTimne2 = new DateTime(17,00,00);

            //if (Start_Time< MaxTime || End_Time >MaxTimne2)
            //{
            //    throw new InvalidOperationException("You cant set Events that are before 8am and until 5pm!");
            //}

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CalendarDB;Trusted_Connection=True;";
            Console.WriteLine("1.Create Event");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command =
                    new SqlCommand("INSERT INTO Events (name,date,start_time,end_time,place,comment) VALUES (@TextValue,@Date,@Start_Time,@End_Time,@Place,@Comment);", connection);
                command.Parameters.AddWithValue("@textValue", TextValue);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@Start_time", Start_Time);
                command.Parameters.AddWithValue("@End_time", End_Time);
                command.Parameters.AddWithValue("@Place", Place);
                command.Parameters.AddWithValue("@Comment", Comment);
                command.ExecuteNonQuery();
                Console.WriteLine("You succsessfully added new Event!");
            }

        }

        public void SearchEvent()
        {

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CalendarDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Enter the name and date of the event?");
                Console.WriteLine("Enter the name!");
                var Name = Console.ReadLine();
                Console.WriteLine("Enter the date!");
                DateTime EvDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Do you want to 1 - Cancel or 2 - Edit the event ?");
                int choise = Int32.Parse(Console.ReadLine());
                if (choise == 1)
                {
                    connection.Open();
                    string query = "DELETE FROM Events WHERE name = @Name AND date = @EvDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EvDate", EvDate);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("You canceled the event succsessfully!");

                }

                if (choise == 2)
                {
                    Console.WriteLine("Enter your new event name!");
                    var NewName = Console.ReadLine();
                    Console.WriteLine("Enter new Date!");
                    DateTime Date = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new StartTime!");
                    DateTime StartTime = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Emter mew EndTime!");
                    DateTime EndTime = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new event Place!");
                    var Place = Console.ReadLine();
                    Console.WriteLine("Enter comment!");
                    var Comment = Console.ReadLine();

                    connection.Open();
                   string query = "UPDATE Events SET (name,date,star_time,end_time,placem,comment) = (@NewName,@Date, @StartTime, @EndTime,@Place,@Comment) WHERE name =@Name";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@NewName", NewName);
                        command.Parameters.AddWithValue("@Date", Date);
                        command.Parameters.AddWithValue("@StartTime", StartTime);
                        command.Parameters.AddWithValue("@EndTime", EndTime);
                        command.Parameters.AddWithValue("@Place", Place);
                        command.Parameters.AddWithValue("@Comment", Comment);
                        command.ExecuteNonQuery();
                    }

                }
            }
        }

        public void Schedule()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CalendarDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Chose what date you want to see your schedule ?");
                    DateTime enterDate = DateTime.Parse(Console.ReadLine());      
                    connection.Open();

                    string query = "SELECT * FROM Events  WHERE date = @EnterDate ORDER BY start_time ASC";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EnterDate", enterDate);
             
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID:{reader[0]}\tname:{reader[1]}\tdate:{reader[2]}\tstart_time:{reader[3]}\tend_time:{reader[4]}\tplace:{reader[5]}\tcomment:{reader[6]}");
                    }
                }

        }


    }
}

            