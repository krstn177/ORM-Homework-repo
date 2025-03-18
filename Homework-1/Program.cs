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
                Console.WriteLine("Database exists");
            }
            else
            {
                CreateDatabase(connectionString, database);
            }
            connectionString = $"Server = Kristiyan\\MSSQLSERVER03;Database={database};Trusted_Connection = true; TrustServerCertificate = true";
            CreateTables(connectionString);
            //InsertProduct(connectionString, "Apples");
            //InsertProduct(connectionString, "Bananas");
            InsertProduct(connectionString, "Oranges");
            //InsertProduct(connectionString, "Mangos");

            //InsertClient(connectionString, "Pesho");
            //InsertClient(connectionString, "Stamat");
            //InsertClient(connectionString, "John");
            //InsertClientTransaction(connectionString, "Steph");

            //ClientToBuyProduct(connectionString, 1, 1);
            //ClientToBuyProduct(connectionString, 2, 3);
            //ClientToBuyProduct(connectionString, 3, 3);
            ClientToBuyProduct(connectionString, 4, 5);

            //DeleteProduct(connectionString, 3);

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
                ClientId INT PRIMARY KEY IDENTITY(1,1),
                Name VARCHAR(20) NOT NULL
            );
        END;";

            string createBuyingsTable = @"
        IF OBJECT_ID('dbo.Buyings', 'U') IS NULL
        BEGIN
            CREATE TABLE dbo.Buyings (
                ClientId INT NOT NULL,
                ProductId INT NOT NULL,
                PRIMARY KEY (ClientId, ProductId),
                FOREIGN KEY (ClientId) REFERENCES dbo.Clients(ClientId) ON DELETE CASCADE,
                FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId) ON DELETE CASCADE
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

                    using (SqlCommand cmd = new SqlCommand(createBuyingsTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Buyings table checked/created successfully.");
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
            string addBuyingQuery = "INSERT INTO Buyings (ClientId, ProductId) VALUES (@ClientId, @ProductId)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(addBuyingQuery, conn))
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

        private static void InsertClientTransaction(string connectionString, string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                SqlTransaction transaction;

                transaction = conn.BeginTransaction();

                cmd.Connection = conn;
                cmd.Transaction = transaction;

                try
                {
                    cmd.CommandText =
                        "INSERT INTO Clients (Name) VALUES (@clientName)";
                    cmd.Parameters.AddWithValue("@clientName", name);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine("Record is written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);

                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {

                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
            }
        }
        static void GetCountOfBuyers(string connectionString) 
        {
            string getCountQuery = "SELECT ProductName, COUNT(DISTINCT Buyings.ClientId) AS ClientCount FROM Buyings JOIN Products ON Buyings.ProductId = Products.ProductId GROUP BY Products.ProductName";
            
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

        static void DeleteProduct(string connectionString, int id)
        {
            string deleteBuyingsQuery = "DELETE FROM Buyings WHERE ProductId = @productId";
            string deleteProductQuery = "DELETE FROM Products WHERE ProductId = @productId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmdDeleteBuyings = new SqlCommand(deleteBuyingsQuery, conn, transaction))
                        {
                            cmdDeleteBuyings.Parameters.AddWithValue("@productId", id);
                            cmdDeleteBuyings.ExecuteNonQuery();
                        }

                        using (SqlCommand cmdDeleteProduct = new SqlCommand(deleteProductQuery, conn, transaction))
                        {
                            cmdDeleteProduct.Parameters.AddWithValue("@productId", id);
                            int rowsAffected = cmdDeleteProduct.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Product and related buyings successfully deleted.");
                                transaction.Commit();
                            }
                            else
                            {
                                Console.WriteLine("No product found with the given ProductId.");
                                transaction.Rollback();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error occurred when deleting the product: {ex.Message}");
                    }
                }
            }
        }

    }
}
