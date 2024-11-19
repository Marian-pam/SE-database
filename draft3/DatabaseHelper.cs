using System;
using System.Data;
using System.Data.SqlClient;

namespace draft3
{
    public class DatabaseHelper : IDisposable
    {
        private readonly SqlConnection _connection;

        // Constructor to initialize the connection
        public DatabaseHelper()
        {
            // Update the connection string as needed
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\togetherCulture.mdf;Integrated Security=True;Connect Timeout=30;";
            _connection = new SqlConnection(connectionString);
        }

        // Open the database connection
        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        // Close the database connection
        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        // Execute a query (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
        }

        // Execute a SELECT query and return a DataTable
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable result = new DataTable();
                    adapter.Fill(result);
                    return result;
                }
            }
        }

        // Implement IDisposable to clean up resources
        public void Dispose()
        {
            CloseConnection();
            _connection.Dispose();
        }
    }
}
