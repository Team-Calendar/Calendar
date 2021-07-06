using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CalendarDBEntities();

            var events = context.Event.ToList();
            var places = context.Place.ToList();

            var place = new Place();
            context.Place.Add(place);
            context.SaveChanges();

            Console.WriteLine(places.Count());

        }
    }
}
