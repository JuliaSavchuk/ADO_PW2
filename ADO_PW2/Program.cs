using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Collections;
using System.ComponentModel.Design;

namespace ADO_PW2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            bool exit = true;
            while (exit)
            {
                Console.WriteLine("\nChoose an option:\n" +
                "1) Connect to Database\n" +
                "2) Disconnect from Database\n" +
                "3) Display All Stationery\n" +
                "4) Display All Types of Stationery\n" +
                "5) Display All Sales Managers\n" +
                "6) Show Stationery with Maximum Number of Units\n" +
                "7) Show Stationery with Minimum Number of Units\n" +
                "8) Show Stationery with Minimum Unit Cost\n" +
                "9) Show Stationery with Maximum Unit Cost\n" +
                "10) Show Stationery by Type\n" +
                "11) Show Stationery Sold by a Manager\n" +
                "12) Show Stationery Sold to a Buyer Firm\n" +
                "13) Show Most Recent Sale\n" +
                "14) Show Average Number of Products Sold per Type\n" +
                "15) Exit");

                string cho = Console.ReadLine();
                int choice = Int32.Parse(cho);
                switch (choice)
                {
                    case 1:
                        ConnectToDatabase();
                        break;
                    case 2:
                        DisconnectFromDatabase();
                        break;
                    case 3:
                        DisplayAllStationery();
                        break;
                    case 4:
                        DisplayAllTypesOfStationery();
                        break;
                    case 5:
                        DisplayAllSalesManagers();
                        break;
                    case 6:
                        ShowMaxUnitsStationery();
                        break;
                    case 7:
                        ShowMinUnitsStationery();
                        break;
                    case 8:
                        ShowMinUnitCostStationery();
                        break;
                    case 9:
                        ShowMaxUnitCostStationery();
                        break;
                    case 10:
                        ShowStationeryByType();
                        break;
                    case 11:
                        ShowStationerySoldByManager();
                        break;
                    case 12:
                        ShowStationerySoldToBuyerFirm();
                        break;
                    case 13:
                        ShowMostRecentSale();
                        break;
                    case 14:
                        ShowAverageNumberOfProductsPerType();
                        break;
                    case 15:
                        exit = false;
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }

        static void ConnectToDatabase()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!"); ;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to connect to the database. Error:");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void DisconnectFromDatabase()
        {
            Console.WriteLine("Disconnected from the database.");
        }

        
        static void DisplayAllStationery()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Stationery";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    Console.WriteLine("Stationery Information:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity: {reader["Quantity"]}, Cost: {reader["Cost"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching stationery data.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void DisplayAllTypesOfStationery()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT [Type] FROM Stationery";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    Console.WriteLine("Types of Stationery:");
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Type"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching types of stationery.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void DisplayAllSalesManagers()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT Manager FROM Sales";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    Console.WriteLine("Sales Managers:");
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Manager"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching sales managers.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void ShowMaxUnitsStationery()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 * FROM Stationery ORDER BY Quantity DESC";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    Console.WriteLine("Stationery with Maximum Units:");
                    if (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity: {reader["Quantity"]}, Cost: {reader["Cost"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching stationery with maximum units.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void ShowMinUnitsStationery()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 * FROM Stationery ORDER BY Quantity ASC";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    Console.WriteLine("Stationery with Minimum Units:");
                    if (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity: {reader["Quantity"]}, Cost: {reader["Cost"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching stationery with minimum units.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void ShowMinUnitCostStationery()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 * FROM Stationery ORDER BY Cost ASC";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    Console.WriteLine("Stationery with Minimum Unit Cost:");
                    if (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity: {reader["Quantity"]}, Cost: {reader["Cost"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching stationery with minimum unit cost.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void ShowMaxUnitCostStationery()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 * FROM Stationery ORDER BY Cost DESC";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    Console.WriteLine("Stationery with Maximum Unit Cost:");
                    if (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity: {reader["Quantity"]}, Cost: {reader["Cost"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching stationery with maximum unit cost.");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void ShowStationeryByType()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            Console.WriteLine("Enter the type of stationery:");
            string type = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Stationery WHERE [Type] = @Type";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Type", type);
                    reader = command.ExecuteReader();

                    Console.WriteLine($"Stationery of type '{type}':");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Quantity: {reader["Quantity"]}, Cost: {reader["Cost"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching stationery by type.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void ShowStationerySoldByManager()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            Console.WriteLine("Enter the manager's name:");
            string manager = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT S.*, ST.Name, ST.Type FROM Sales S JOIN Stationery ST ON S.StationeryId = ST.Id WHERE S.Manager = @Manager";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Manager", manager);
                    reader = command.ExecuteReader();

                    Console.WriteLine($"Stationery sold by manager '{manager}':");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Sale Id: {reader["Id"]}, Stationery Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity Sold: {reader["QuantitySold"]}, Price: {reader["PricePerUnit"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching stationery sold by manager.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void ShowStationerySoldToBuyerFirm()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            Console.WriteLine("Enter the buyer's company name:");
            string buyerCompany = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT S.*, ST.Name, ST.Type FROM Sales S JOIN Stationery ST ON S.StationeryId = ST.Id WHERE S.BuyerCompany = @BuyerCompany";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BuyerCompany", buyerCompany);
                    reader = command.ExecuteReader();

                    Console.WriteLine($"Stationery purchased by buyer company '{buyerCompany}':");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Sale Id: {reader["Id"]}, Stationery Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity Sold: {reader["QuantitySold"]}, Price: {reader["PricePerUnit"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching stationery sold to buyer firm.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void ShowMostRecentSale()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 S.*, ST.Name, ST.Type FROM Sales S JOIN Stationery ST ON S.StationeryId = ST.Id ORDER BY S.SaleDate DESC";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    Console.WriteLine("Most recent sale:");
                    if (reader.Read())
                    {
                        Console.WriteLine($"Sale Id: {reader["Id"]}, Stationery Name: {reader["Name"]}, Type: {reader["Type"]}, Quantity Sold: {reader["QuantitySold"]}, Price: {reader["PricePerUnit"]}, Sale Date: {reader["SaleDate"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while fetching the most recent sale.");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void ShowAverageNumberOfProductsPerType()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ST.Type, AVG(S.QuantitySold) AS AvgSold FROM Sales S JOIN Stationery ST ON S.StationeryId = ST.Id GROUP BY ST.Type";
                SqlDataReader reader;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    Console.WriteLine("Average number of products sold per type:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Type: {reader["Type"]}, Average Quantity Sold: {reader["AvgSold"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while calculating average quantity sold per type.");
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
