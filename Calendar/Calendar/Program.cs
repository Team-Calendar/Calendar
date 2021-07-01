using System;

namespace Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Int32.Parse(Console.ReadLine());
            UserMenu menu = new UserMenu(a);

            menu.UserMneu();
        }
    }
}
