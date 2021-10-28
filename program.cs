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
                    insertdata();
                    break;
                case "Reports":
                    selectreport();
                    break;
                default:
                    Console.WriteLine("Enter your choice again");
                    break;
            }

            void insertdata()
            {
                string insertquery = "INSERT INTO sale (ProductName, Quantity, Price, SaleDate) VALUES('Air Fryer', 56, 7.99, '2008-11-15')";

                sendCommand(insertquery);


            }

            void selectreport()
            {

                string seconduserinput;

                Console.WriteLine("Enter your choice: ");
                string userinput = Console.ReadLine();

                switch (userinput)
                {

                    case "year":
                        Console.WriteLine("Input a year: ");
                        string yearsql = "select * from sale where year(SaleDate) = " + userinput;
                        sendCommand(yearsql);
                        break;
                    case "year month":
                        Console.WriteLine("Please enter a year: ");
                        userinput = Console.ReadLine();
                        Console.WriteLine("Please enter a month: ");
                        seconduserinput = Console.ReadLine();
                        string yearmonthsql = "select * from sale where year(SaleDate) = " + userinput + "AND  month(SaleDate) = " + seconduserinput;
                        break;
                    case "total year":
                        Console.WriteLine("Please enter a year: ");
                        userinput = Console.ReadLine();
                        string countyearsql = "select count(SaleDate) from sales where year(SaleDate) = " + userinput;
                        sendCommand(sqlcountyear);
                        break;
                    case "total year month":
                        Console.WriteLine("Please enter a year: ");
                        userinput = Console.ReadLine();
                        Console.WriteLine("Please enter a month: ");
                        seconduserinput = Console.ReadLine();
                        string countyearmonthsql = "select count(SaleDate) from sales where year(SaleDate) = " + userinput + " AND month(SaleDate) = " + userinput2;
                        sendCommand(countyearmonthsql);
                        break;
                    default:
                        Console.WriteLine("please enter your choice again");
                        break;
                }
            }
        }
    }
}