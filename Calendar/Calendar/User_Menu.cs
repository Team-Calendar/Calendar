using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Calendar
{
    class User_Menu
    {
        public void UserChoice()
        {
            Console.WriteLine("Please choose what to do (1 - Create an event | 2 -Search event  | 3 - Daily schedule | 4 - Find availability)");
            int a = Int32.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Create_Event newEvent = new Create_Event();
                    newEvent.InsertThem();
                    break;
                case 2:
                    Search_Event newdeleter = new Search_Event();
                    newdeleter.Delete();
                    break;
                case 3:
                   Daily_schedule newschedule = new Daily_schedule();
                  newschedule.Schedule();
                   break;
                //case 4:
                //    Find_availability newavailability = Find_availability();
                //    break;
            }
        }
    }
}