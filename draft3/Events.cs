using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YourNamespace;

namespace draft3
{
    public partial class Events : Form
    {
        private bool isAlphabetical = false; // Flag to track sorting order

        public Events()
        {
            InitializeComponent(); // Initialize the form and its components
            LoadData(); // Load data into the ListBox when the form is opened
        }

        /// <summary>
        /// Fetches data from the database and populates the ListBox.
        /// </summary>
        private void LoadData()
        {
            try
            {
                // SQL query to select data from the Events table
                string query = "SELECT [Event name] FROM Events"; // Enclose column name in brackets as it is 2 words instead of 1

                // Fetch data using the DatabaseHelper method
                List<string> data = DatabaseHelper.GetData(query, "Event name");

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
                    MessageBox.Show("No events found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occur during the data retrieval
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Events_Load(object sender, EventArgs e)
        {
            // Optional error message in case it doesn't work
            try
            {
                this.eventsTableAdapter.Fill(this.togetherCultureDataSet.Events);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data from DataSet: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selection change in the ListBox if needed
            string selectedEvent = listBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedEvent))
            {
                MessageBox.Show($"You selected: {selectedEvent}", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ToggleSortButton_Click_1(object sender, EventArgs e)
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
