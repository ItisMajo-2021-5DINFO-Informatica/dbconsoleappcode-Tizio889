using System;
using Microsoft.Data.SqlClient;

namespace DBConsoleApp
{
    class Program
    {


        static void Main(string[] args)
        {
            
            

            try
            {

                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    string i;
                    Console.WriteLine("inserire L'id da cercare");
                    i = Console.ReadLine();

                    connection.Open();

                    String sql = "SELECT CustomerID, ShipName FROM Orders WHERE CustomerID ='" + i + "'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }
    }
}
