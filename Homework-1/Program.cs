using Microsoft.Data.SqlClient;

namespace Homework_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=Kristiyan\\MSSQLSERVER03;Trusted_Connection=true;TrustServerCertificate=true";
            string database = "Products";
            if (DatabaseExists(connectionString, database))
            {
                Console.WriteLine("It exists");
            }
            else
            {
                CreateDatabase(connectionString, database);
            }
            connectionString = $"Server = Kristiyan\\MSSQLSERVER03;Database={database};Trusted_Connection = true; TrustServerCertificate = true";
            CreateTables(connectionString);
            InsertClient(connectionString, "Pesho");
            InsertClient(connectionString, "Stamat");
            InsertClient(connectionString, "John");
            InsertClient(connectionString, "Mark");
            InsertProduct(connectionString, "Apples");
            InsertProduct(connectionString, "Bananas");
            InsertProduct(connectionString, "Oranges");
            InsertProduct(connectionString, "Mangos");

            ClientToBuyProduct(connectionString, 1, 1);
            ClientToBuyProduct(connectionString, 2, 3);
            ClientToBuyProduct(connectionString, 3, 3);
            ClientToBuyProduct(connectionString, 4, 3);

            GetCountOfBuyers(connectionString);

        }

        static bool DatabaseExists(string connectionString, string database)
        {
            string query = "SELECT database_id FROM sys.databases WHERE name = @database";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@database", database);
                try
                {
                    conn.Open();
                    return cmd.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error checking database existence: " + ex.Message);
                    return false;
                }
            }
        }

        static void CreateDatabase(string connectionString,string databaseName)
        {
            string createDbQuery = $"CREATE DATABASE {databaseName}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(createDbQuery, conn)) 
            {
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Successfully Created");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database not created successfuly: {ex.Message}");
                }
            }
        }

        static void CreateTables(string connectionString)
        {
            string createProductsTableQuery = @"
        IF OBJECT_ID('dbo.Products', 'U') IS NULL
        BEGIN
            CREATE TABLE dbo.Products (
                ProductId INT PRIMARY KEY IDENTITY(1,1),
                ProductName VARCHAR(20) NOT NULL
            );
        END;";

            string createClientsTableQuery = @"
        IF OBJECT_ID('dbo.Clients', 'U') IS NULL
        BEGIN
            CREATE TABLE dbo.Clients (
                Id INT PRIMARY KEY IDENTITY(1,1),
                Name VARCHAR(20) NOT NULL,
                ProductId INT,
                FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId)
            );
        END;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(createProductsTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Products table checked/created successfully.");
                    }

                    using (SqlCommand cmd = new SqlCommand(createClientsTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Clients table checked/created successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating/checking tables: {ex.Message}");
                }
            }
        }

        static void InsertProduct(string connectionString, string productName)
        {
            string insertProductQuery = "INSERT INTO Products (ProductName) VALUES (@productName)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertProductQuery, conn)) 
            {
                cmd.Parameters.AddWithValue("@productName", productName);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Product inserted");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting product: {ex.Message}");
                }
            }
        }

        static void InsertClient(string connectionString, string clientName)
        {
            string insertClientQuery = "INSERT INTO Clients (Name) VALUES (@clientName)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertClientQuery, conn))
            {
                cmd.Parameters.AddWithValue("@clientName", clientName);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Client inserted");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting client: {ex.Message}");
                }
            }
        }

        static void ClientToBuyProduct(string connectionString, int ClientId, int ProductId )
        {
            string updateClientRecordQuery = "UPDATE Clients SET ProductId = @ProductId WHERE Id = @ClientId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateClientRecordQuery, conn))
            {
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                cmd.Parameters.AddWithValue("@ClientId", ClientId);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Client: {ClientId} bought Product: {ProductId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error buying product: {ex.Message}");
                }
            }
        }

        static void GetCountOfBuyers(string connectionString) 
        {
            string getCountQuery = "SELECT ProductName, COUNT(Clients.Id) AS ClientCount FROM Clients JOIN Products ON Clients.ProductId = Products.ProductId GROUP BY ProductName";
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(getCountQuery, conn))
            {
                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productName = reader["ProductName"].ToString();
                            int clientCount = Convert.ToInt32(reader["ClientCount"]);
                            Console.WriteLine($"Product: {productName}, Buyers: {clientCount}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching buyer count: " + ex.Message);
                }
            }
        }

    }
}
