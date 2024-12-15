using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YourNamespace;

namespace draft3
{
    public partial class Events : Form
    {
        private bool isAlphabetical = false; // Keeps track of whether events are sorted alphabetically

        public Events()
        {
            InitializeComponent(); 
            LoadData(); 
        }

        private void LoadData()
        {
            try
            {
                // Here's the SQL query fetches all event names from the Events table. Column name has spaces, so it's wrapped in brackets.
                string query = "SELECT [Event name] FROM Events";

                // Use the DatabaseHelper class to get the event data from the database.
                List<string> data = DatabaseHelper.GetData(query, "Event name");

                if (isAlphabetical)
                {
                    data = data.OrderBy(item => item).ToList(); // Sort the events alphabetically
                }

                // Clear the ListBox first to avoid doubling up on entries.
                listBox1.Items.Clear();

                // Loop through each event and add it to the ListBox for display.
                foreach (string item in data)
                {
                    listBox1.Items.Add(item);
                }

                if (data.Count == 0)
                {
                    MessageBox.Show("No events found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Something went wrong while fetching or displaying data—let the user know.
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Events_Load(object sender, EventArgs e)
        {

            try
            {
                // Fills the dataset using the table adapter.
                this.eventsTableAdapter.Fill(this.togetherCultureDataSet.Events);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error loading data from DataSet: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This runs when the user picks an item from the ListBox.
            string selectedEvent = listBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedEvent))
            {
                // Show a pop-up telling the user which event they picked.
                MessageBox.Show($"You selected: {selectedEvent}", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ToggleSortButton_Click_1(object sender, EventArgs e)
        {
            isAlphabetical = !isAlphabetical;

            // Refresh the ListBox to apply the new sorting order.
            LoadData();

            // Update the button text to let the user know what the sorting mode is now.
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
