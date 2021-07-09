using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar_final_version
{
    class Events
    {
        public void UserChoice()
        {
            int a = Int32.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    InsertingEvents NewInserter = new InsertingEvents();
                    NewInserter.InsertThem();
                    break;
                case 2:
                    DeletingAnEvent NewDeleter = new DeletingAnEvent();
                    NewDeleter.Delet();
                    break;
                case 3:
                    SavingHours NewSaver = new SavingHours();
                    NewSaver.SelectEvent();
                    break;
                    //case 4:

                    //    break;
            }
        }
    }
}
