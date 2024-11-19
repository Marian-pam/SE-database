using System;
using System.Data.SqlClient;

namespace draft3
{
    public class DatabaseConnection
    {
        private string connectionString;

        // Constructor to initialize the connection string
        public DatabaseConnection()
        {
            // Replace the path below with the actual path to your .mdf file
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\togetherCulture.mdf;Integrated Security=True";
        }

        /// <summary>
        /// Tests the database connection.
        /// </summary>
        /// <returns>True if connection is successful, otherwise false.</returns>
        public bool TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Connection failed: {ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserts a new user into the database.
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        public void InsertUser(string email, string password)
        {
            string query = "INSERT INTO Users (Email, Password) VALUES (@Email, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("User inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting user: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        public void GetAllUsers()
        {
            string query = "SELECT * FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Email: {reader["Email"]}, Password: {reader["Password"]}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving users: {ex.Message}");
                }
            }
        }
    }
}
