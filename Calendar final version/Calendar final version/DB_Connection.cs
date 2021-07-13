using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_final_version
{
    //#daPipnemCoda
    class DB_Connection
    {
        public string ConnectionString { get; set; }

        public DB_Connection()
        {
            this.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CalendarDB;Trusted_Connection=True;";
        }
        public void CreateEvent(string TextValue, DateTime Date, DateTime Start_Time, DateTime End_Time, string Place, string Comment)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
        public void DealeteEvent(string Name, DateTime EveDate)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM Events WHERE name = @Name AND date = @EvDate";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EvDate", EveDate);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("You canceled the event succsessfully!");
            }
        }
        public void EditEvent(string Name, DateTime EvDate, string NewName, DateTime date, DateTime StartTime, DateTime EndTime, string place, string comment)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "UPDATE Events SET name=@NewName , date = @date , start_time = @StartTime ,end_time = @EndTime , place = @place , comment =@comment WHERE name =@Name AND date =@EvDate";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EvDate", EvDate);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@NewName", NewName);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@StartTime", StartTime);
                    command.Parameters.AddWithValue("@EndTime", EndTime);
                    command.Parameters.AddWithValue("@Place", place);
                    command.Parameters.AddWithValue("@Comment", comment);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Event changed successfully!");
            }
        }
        public void Schedule(DateTime enterDate)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Events  WHERE date = @EnterDate ORDER BY start_time ASC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EnterDate", enterDate);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID:{reader[0]}\tname:{reader[1]}\tdate:{DateTime.Parse(reader[2].ToString()).ToString("dd.MM.yyyy")}\tstart_time:{reader[3]}\tend_time:{reader[4]}\tplace:{reader[5]}\tcomment:{reader[6]}");
                }
            }
        }
        public void FindAvailability(TimeSpan Start_Time)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Events  WHERE NOT @Start_Time BETWEEN start_time AND end_time ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Start_Time", Start_Time);
                    command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"You have avable hours on {reader[2]}\tstart_time:{reader[3]}\tend_time:{reader[4]}");
                    }
                }
            }
        }
        public void PrintAllEvents()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Events ORDER BY date ASC";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID:{reader[0]}\tname:{reader[1]}\tdate:{DateTime.Parse(reader[2].ToString()).ToString("dd.MM.yyyy")}\tstart_time:{reader[3]}\tend_time:{reader[4]}\tplace:{reader[5]}\tcomment:{reader[6]}");
                }
            }
        }
    }
}
