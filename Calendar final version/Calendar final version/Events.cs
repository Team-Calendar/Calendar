﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Calendar_final_version
{
    class Events
    {
        public string TextValue { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public string Place { get; set; }
        public string Comment { get; set; }

        public Events(string T, DateTime D, DateTime S, DateTime E, string P, string C)
        {
            this.TextValue = T;
            this.Date = D;
            this.Start_Time = S;
            this.End_Time = E;
            this.Place = P;
            this.Comment = C;
        }

        public Events()
        {
            this.TextValue = "Nothing";
            this.Place = "Nothing";
            this.Comment = "Nothing";
        }
        public void CreateEvent()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CalendarDB;Trusted_Connection=True;";
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
      
        public void EditEvent()
        {
            Console.WriteLine("Enter the event name you want to Edit.");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter the event date you want to Edit.");
            DateTime EvDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter your new event name.");
            string NewName = Console.ReadLine();
            Console.WriteLine("Enter new Date./dd.mm.yyyy");
            DateTime Date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter new StartTime./hh:mm:ss");
            DateTime StartTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter mew EndTime./hh:mm:ss");
            DateTime EndTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter new event Place.");
            string Place = Console.ReadLine();
            Console.WriteLine("Enter comment.");
            string Comment = Console.ReadLine();
            if (string.IsNullOrEmpty(NewName) || string.IsNullOrEmpty(Place) || string.IsNullOrEmpty(Comment))
            {
                Console.WriteLine("You entered a non-valid information!");
                Console.ReadLine();
                Console.Clear();
                EditEvent();
            }
            if (StartTime.Hour < 8 || EndTime.Hour > 17)
            {
                Console.WriteLine("Please enter an event between 8am and 5pm!");
                Console.ReadLine();
                Console.Clear();
                EditEvent();
            }
            DB_Connection Edit = new DB_Connection();
            Edit.EditEvent(Name, EvDate, NewName, Date, StartTime, EndTime, Place, Comment);
        }

        public void CancelEvent()
        {
            Console.WriteLine("Enter the name and date of the event.");
            Console.WriteLine("Enter the name.");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter the date./dd.mm.yyyy");
            DateTime EvDate = DateTime.Parse(Console.ReadLine());
            DB_Connection Cancel = new DB_Connection();
            Cancel.DealeteEvent(Name, EvDate);
        }

        public void Schedule()
        {
            Console.WriteLine("Chose what date you want to see your schedule./dd.mm.yyyy");
            DateTime ScheduleDate = DateTime.Parse(Console.ReadLine());
            DB_Connection Schedule = new DB_Connection();
            Schedule.Schedule(ScheduleDate);
        }

        public void FindAvailability()
        {
            Console.WriteLine("Enter the  tart time./hh:mm:ss");
            TimeSpan Start_Time = TimeSpan.Parse(Console.ReadLine());
            DB_Connection Availability = new DB_Connection();
            Availability.FindAvailability(Start_Time);

        }

    }
}
