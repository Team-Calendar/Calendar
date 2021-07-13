using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calendar
{
    class Search_Event
    {
        public void Delete()
        {

            string connectionString = "Data Source=DESKTOP-L2ESCEA\\MSSQLSERVER01;Initial Catalog=Calendar;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Search for the Event name.");
                var TextDeleter = Console.ReadLine();
                Console.WriteLine("Do you want to Cancel or Edit the event ?");
                var choise = Console.ReadLine();
                if (choise == "Cancel")
                {
                    connection.Open();
                    string query = "DELETE FROM EVENTS WHERE (name) = (@TextDeleter)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TextDeleter", TextDeleter);
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("You canceled the event succsessfully!");

                }

                if (TextDeleter =="Edit")
                {

                }

            }


             
        }

    }
}