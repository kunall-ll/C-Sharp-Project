using System;
using System.Data;
using System.Data.SqlClient;

namespace SalesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (userinput)
            {
                case "Data Entry":
                    insert();
                    break;
                case "Reports":
                    select();
                    break;
                default:
                    Console.WriteLine("Enter your choice again");
                    break;
            }

            void insert()
            {
                string insertquery = "INSERT INTO sale (ProductName, Quantity, Price, SaleDate) VALUES('Air Fryer', 56, 7.99, '2008-11-15')";

                sendCommand(insertquery);


            }
        }
    }
}