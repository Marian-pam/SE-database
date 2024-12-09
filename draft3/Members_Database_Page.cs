using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Add this for SQL Server operations

namespace draft3
{
    public partial class Members_Database_Page : Form
    {
        private bool isAlphabetical = false; // Flag to track sorting order
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\togetherCulture.mdf;Integrated Security=True"; 

        public Members_Database_Page()
        {
            InitializeComponent();
            LoadData(); // Load data into the ListBox when the form is opened
        }

        /// <summary>
        /// Fetches data from the database and populates the ListBox.
        /// </summary>
        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT [First Name], [Surname], [Membership Status] FROM [Founding Members]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> data = new List<string>();
                            while (reader.Read())
                            {
                                string item = $"{reader["First Name"]} {reader["Surname"]} - {reader["Membership Status"]}";
                                data.Add(item);
                            }

                            // Apply sorting if the alphabetical flag is true
                            if (isAlphabetical)
                            {
                                data = data.OrderBy(item => item).ToList();
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
                    }
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occur during the data retrieval
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Members_Database_Page_Load(object sender, EventArgs e)
        {
            // Optional: Add any initialization code here
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selection change in the ListBox if needed
            string selectedMember = listBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedMember))
            {
                MessageBox.Show($"You selected: {selectedMember}", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

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

        private void button7_Click(object sender, EventArgs e)
        {
            AdminDashboard f2 = new AdminDashboard();
            f2.Show();
            Visible = false;
        }
    }
}