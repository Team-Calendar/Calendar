using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_final_version
{ 
    class Program

    {

        private static void ValidateData(string NewName, DateTime StartTime, DateTime EndTime, string Place, string Comment)
        {
            if (string.IsNullOrEmpty(NewName) || string.IsNullOrEmpty(Place) || string.IsNullOrEmpty(Comment))
            {
                Console.WriteLine("You entered a non-valid information!");
                Console.ReadLine();
                Console.Clear();
                CreateEvent();
            }
            if (StartTime.Hour < 8 || EndTime.Hour > 17)
            {
                Console.WriteLine("Please enter an event between 8am and 5pm!");
                Console.ReadLine();
                Console.Clear();
                CreateEvent();
            }
        }
        private static void CreateEvent()
        {
            Console.WriteLine("Enter your new event name.");
            string NewName = Console.ReadLine();
            Console.WriteLine("Enter new Date!/mm.dd.yyyy");
            string a = Console.ReadLine();
            DateTime Date = DateTime.MinValue;
            if (!DateTime.TryParse(a, out Date))
            {
                Console.WriteLine("Please enter valid date");
                CreateEvent();
                return;
            }
            Console.WriteLine("Enter new StartTime!/hh:mm:ss");
            string Starttime = Console.ReadLine();
            DateTime StartTime = DateTime.MinValue;
            if (!DateTime.TryParse(Starttime, out StartTime))
            {
                Console.WriteLine("Please enter valid date");
                CreateEvent();
                return;
            }
            Console.WriteLine("Enter mew EndTime!/hh:mm:ss");
            string Endtime = Console.ReadLine();
            DateTime EndTime = DateTime.MinValue;
            if (!DateTime.TryParse(Endtime, out EndTime))
            {
                Console.WriteLine("Please enter valid date");
                CreateEvent();
                return;
            }
            Console.WriteLine("Enter new event Place.");
            string Place = Console.ReadLine();
            Console.WriteLine("Enter comment.");
            string Comment = Console.ReadLine();
            ValidateData(NewName, StartTime, EndTime, Place, Comment);
            Events User = new Events(NewName, Date, StartTime, EndTime, Place, Comment);
            User.CreateEvent();
        }
        private static void Choise()
        {
            Console.WriteLine("Please choose what to do (1 - Create an event | 2-Cancel | 3 - Edit | 4 - Daily schedule | 5-Find availability)");
            Events EventEditor = new Events();
            int a = Int32.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    CreateEvent();
                    break;
                case 2:
                    EventEditor.CancelEvent();
                    break;
                case 3:
                    EventEditor.EditEvent();
                    break;
                case 4:
                    EventEditor.Schedule();
                    break;
                case 5:
                    EventEditor.FindAvailability();
                    break;
                default:
                    Console.WriteLine("Please choose correct choise!");
                    Choise();
                    break;
            }
        }
        static void Main(string[] args)
        {
            Choise();
            Console.WriteLine("Do you want to return in the user menu?/Yes or No:");
            string answer = Console.ReadLine();
            while (answer == "Yes" || answer == "y" || answer == "yes")
            {
                if (answer == "Yes" || answer == "y" || answer == "yes")
                {
                    Choise();
                    Console.WriteLine("Do you want to continue?");
                    string answer2 = Console.ReadLine();
                    if (answer2 == "No" || answer2 == "n" || answer2 == "No")
                    {
                        break;
                    }
                }
                if (answer == "No" || answer == "n" || answer == "No")
                {
                    break;
                }
            }
        }
    }
}
