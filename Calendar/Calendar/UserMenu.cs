using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar
{
    class UserMenu
    {
        private int userChoise { get; set; }

        public UserMenu(int U)
        {
            this.userChoise = U;

        }

        public void PrintOption()
        {
            Console.WriteLine("1. Create an event 2.Daily schedule 3.Search event 4.Find availability");
            switch (userChoise)
            {
                case 1:
                    //CreateEvent();//this is class
                    break;
                case 2:
                    //PrintDailyProgram();// this is method
                    break;
                case 3:
                    //SearchEvent();// this is method
                    break;
                case 4:
                    //FindFreePlace();//this is method
                    break;
            }
        }
    }
}
