using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string for the SQL Server database
        string connectionString = "Data Source=Amaze\\SQLEXPRESS;Initial Catalog=things_to_do;Integrated Security=True";

        // Variable for the WHERE clause
        int categoryId = 1;

        // SQL SELECT query with a parameterized WHERE clause
        string sqlQuery = "SELECT * FROM dbo.tbl_Items WHERE itid = @categoryId";

        // Create a SqlConnection and execute the parameterized query
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                // Add parameter to the query
                command.Parameters.AddWithValue("@CategoryId", categoryId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Rest of the code remains unchanged
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int itid = reader.GetInt32(0);
                            string name = reader.GetString(1);

                            Console.WriteLine($"Item ID: {itid}, Item Name: {name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                }
            }
        }
    }
}

