﻿using Calendar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    class Program
    {

        static void Main(string[] args)
        {
            User_Menu user = new User_Menu();
            user.UserChoice();
            Console.ReadLine();
        }

    }
}