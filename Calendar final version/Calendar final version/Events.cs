using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Calendar_final_version
{
    class Events
    {
        public void UserChoice()
        {
            Console.WriteLine("Please choose what to do (1 - Create an event | 2- Search event | 3 - Daily schedule | 4 - Find availability)");
            int a = Int32.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("Enter your new event name.");
                    string NewName = Console.ReadLine();
                    Console.WriteLine("Enter new Date!/dd.mm.yyyy");
                    DateTime Date = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new StartTime!/hh:mm:ss");
                    DateTime StartTime = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Emter mew EndTime!/hh:mm:ss");
                    DateTime EndTime = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new event Place.");
                    string Place = Console.ReadLine();
                    Console.WriteLine("Enter comment.");
                    string Comment = Console.ReadLine();
                    DB_Connection User = new DB_Connection(NewName, Date, StartTime, EndTime, Place, Comment);
                    User.CreateEvent();
                    break;

                case 2:
                    DB_Connection User2 = new DB_Connection();
                    User2.SearchEvent();
                    break;

                case 3:
                    DB_Connection User3 = new DB_Connection();
                    User3.Schedule();
                    break;

                case 4:
                    DB_Connection User4 = new DB_Connection();
                    User4.FindAvailability();
                    break;
            }   



        }
    }
}
