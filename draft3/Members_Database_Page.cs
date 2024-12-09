using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace draft3
{
    public partial class Members_Database_Page : Form
    {
        private bool isAlphabetical = false; // Flag to track sorting order

        public Members_Database_Page()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fetches data from the Founding Members table and populates the ListBox.
        /// </summary>
        private void LoadData()
        {
            try
            {
                // SQL query to select data from the Founding Members table
                string query = "SELECT [First Name], [Surname], [Membership Status] FROM [Founding Members]";

                // Fetch data using the DatabaseHelper method
                List<string> data = DatabaseHelper.GetData(query, "First Name", "Surname", "Membership Status");

                // Apply sorting if the alphabetical flag is true
                if (isAlphabetical)
                {
                    data = data.OrderBy(item => item).ToList(); // Sort alphabetically
                }

                // Clear the ListBox to avoid duplicate entries
                listBox1.Items.Clear();

                // Populate the ListBox with data from the table
                foreach (string item in data)
                {
                    listBox1.Items.Add(item);
                }

                // Notify if no data was found in the table
                if (data.Count == 0)
                {
                    MessageBox.Show("No members found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occur during the data retrieval
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the form's Load event.
        /// </summary>
        private void Members_Database_Page_Load(object sender, EventArgs e)
        {
            // Load data into the ListBox directly using SQL query
            LoadData();
        }

        /// <summary>
        /// Handles the selection change event in the ListBox.
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the ListBox
            string selectedMember = listBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedMember))
            {
                MessageBox.Show($"You selected: {selectedMember}", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the Click event of the ToggleSortButton to toggle sorting.
        /// </summary>
        private void ToggleSortButton_Click(object sender, EventArgs e)
        {
            // Toggle the sorting order flag
            isAlphabetical = !isAlphabetical;

            // Reload the data with the new sorting order
            LoadData();

            // Update the button text to indicate the current state
            Button button = sender as Button;
            if (button != null)
            {
                button.Text = isAlphabetical ? "Sort: Alphabetical" : "Sort: Original";
            }
        }

        /// <summary>
        /// Handles the Click event of the Back button to navigate to the Admin Dashboard.
        /// </summary>
        private void button7_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            Visible = false;
        }
    }

    /// <summary>
    /// Helper class for database operations.
    /// </summary>
    public static class DatabaseHelper
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\togetherCulture.mdf;Integrated Security=True";

        /// <summary>
        /// Fetches data from the specified columns in the given query.
        /// </summary>
        public static List<string> GetData(string query, params string[] columns)
        {
            List<string> results = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Combine the values from the specified columns
                                string row = string.Join(" ", columns.Select(col => reader[col].ToString()));
                                results.Add(row);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return results;
        }
    }
}
