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

        static void Main(string[] args)
        {
            Events user = new Events();
            user.UserChoice();
            Console.ReadLine();
        }

    }
}