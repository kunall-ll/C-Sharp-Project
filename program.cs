using System;
using System.Data;
using System.Data.SqlClient;

namespace SalesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlDataReader sendCommand(string query) //establishes sql database connection to reports database
            {

                string connectionString = "Server = Placeholder; Database= reports;";
                SqlConnection connection = new SqlConnection(@connectionString);
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("SUCCESS");
                    return reader;
                }
                catch
                {
                    Console.WriteLine("ERROR");
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }

            void insertdata() //populates database
            {
                string insertquery = "INSERT INTO sale (ProductName, Quantity, Price, SaleDate) VALUES('Air Fryer', 56, 7.99, '2008-11-15')";

                sendCommand(insertquery);


            }


            Console.WriteLine("Choose what you want to do: \n Data Entry \n Reports "); //user choice within console

            string userinput = Console.ReadLine();
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


            void selectreport() //gathers user input with database commands 
            {

                string seconduserinput;
                string thirduserinput;
                string fourthuserinput;

                Console.WriteLine("Enter your choice: ");
                string userinput = Console.ReadLine();

                switch (userinput)
                {

                    case "year":
                        Console.WriteLine("Input a year: ");
                        string yearsql = "SELECT * FROM sale WHERE year(SaleDate) = " + userinput;
                        sendCommand(yearsql);
                        break;
                    case "year month":
                        Console.WriteLine("Please enter a year: ");
                        userinput = Console.ReadLine();
                        Console.WriteLine("Please enter a month: ");
                        seconduserinput = Console.ReadLine();
                        string yearmonthsql = "SELECT * FROM sale WHERE year(SaleDate) = " + userinput + "AND  month(SaleDate) = " + seconduserinput;
                        sendCommand(yearmonthsql);
                        break;
                    case "total year":
                        Console.WriteLine("Please enter a year: ");
                        userinput = Console.ReadLine();
                        string countyearsql = "SELECT count(SaleDate) FROM sale WHERE year(SaleDate) = " + userinput;
                        SqlDataReader test = sendCommand(countyearsql);

                        while (test.Read())
                        {
                            for (int i = 0; i < test.FieldCount; i++)
                            {
                                Console.Write(test[i] + ",");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "total year month":
                        Console.WriteLine("Please enter a year: ");
                        userinput = Console.ReadLine();
                        Console.WriteLine("Please enter a month: ");
                        seconduserinput = Console.ReadLine();
                        string countyearmonthsql = "SELECT count(SaleDate) FROM sale WHERE year(SaleDate) = " + userinput + " AND month(SaleDate) = " + seconduserinput;
                        SqlDataReader test2 = sendCommand(countyearmonthsql);

                        while (test2.Read())
                        {
                            for (int i = 0; i < test2.FieldCount; i++)
                            {
                                Console.Write(test2[i] + ",");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "between two years":
                        Console.WriteLine("Please enter 1st year: ");
                        userinput = Console.ReadLine();
                        Console.WriteLine("Please enter 2nd year: ");
                        seconduserinput = Console.ReadLine();
                        string betweentwoyearssql = "SELECT * FROM sale WHERE year(SaleDate) between " + userinput + " AND " + seconduserinput;
                        SqlDataReader test3 = sendCommand(betweentwoyearssql);

                        while (test3.Read())
                        {
                            for (int i = 0; i < test3.FieldCount; i++)
                            {
                                Console.Write(test3[i] + ",");
                            }
                            Console.WriteLine();
                        }

                    case "betweentwodates":
                        Console.WriteLine("Please enter 1st year: ");
                        userinput = Console.ReadLine();
                        Console.WriteLine("Please enter 1st month: ");
                        seconduserinput = Console.ReadLine();
                        Console.WriteLine("Please enter 2nd year: ");
                        thirduserinput = Console.ReadLine();
                        Console.WriteLine("Please enter 2nd month: ");
                        fourthuserinput = Console.ReadLine();
                        string betweentwodatessql = "SELECT * FROM sale WHERE SaleDate between " + seconduserinput + " AND " + userinput + "AND" + fourthuserinput + "AND" + thirduserinput;
                        SqlDataReader test4 = sendCommand(betweentwodatessql);

                        while (test4.Read())
                        {
                            for (int i = 0; i < test4.FieldCount; i++)
                            {
                                Console.Write(test4[i] + ",");
                            }
                            Console.WriteLine();
                        }

                    default:
                        Console.WriteLine("please enter your choice again");
                        break;
                }

            }
        }
    }
}