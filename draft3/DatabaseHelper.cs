using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace YourNamespace
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;

        /// <summary>
        /// Executes a query and returns a list of results.
        /// </summary>
        /// <param name="query">The SQL query to execute.</param>
        /// <param name="columnName">The column name to extract data from.</param>
        /// <returns>A list of string data from the specified column.</returns>
        public static List<string> GetData(string query, string columnName)
        {
            List<string> dataList = new List<string>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dataList.Add(reader[columnName].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Log or handle the exception as needed
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return dataList;
        }
    }
}
