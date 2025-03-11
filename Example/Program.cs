using Microsoft.Data.SqlClient;

namespace Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=Kristiyan\\MSSQLSERVER03;Database=AdventureWorksLT2019;Trusted_Connection=true;TrustServerCertificate=true";
            string queryString = "SELECT * FROM SalesLT.Products";

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.ExecuteReader();
                }
                catch (Exception)
                {

                    throw;
                }
                finally 
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
