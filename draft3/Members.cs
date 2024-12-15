using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace draft3
{
    public partial class Members : Form
    {
        // This flag determines whether the member list is sorted alphabetically
        private bool isAlphabetical = false;

        // Connection string for the database
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\togetherCulture.mdf;Integrated Security=True";

        public Members()
        {
            InitializeComponent(); 
            LoadData(); 
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to fetch member details
                    string query = "SELECT [First Name], [Surname], [Membership Status] FROM [Founding Members]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> data = new List<string>();
                            while (reader.Read())
                            {
                                // Combine first name, surname, and membership status into a single string
                                string item = $"{reader["First Name"]} {reader["Surname"]} - {reader["Membership Status"]}";
                                data.Add(item);
                            }

                            if (isAlphabetical)
                            {
                                data = data.OrderBy(item => item).ToList();
                            }
                      
                            listBox1.Items.Clear();

                            // Add the retrieved data to the ListBox
                            foreach (string item in data)
                            {
                                listBox1.Items.Add(item);
                            }

                            // Notify the user if no members were found
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
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Members_Database_Page_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the event when the user selects a member from the ListBox
            string selectedMember = listBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedMember))
            {
                try
                {
                    // Split the selected item to extract the first name and surname
                    string[] memberParts = selectedMember.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (memberParts.Length >= 2) // Ensure valid selection
                    {
                        string firstName = memberParts[0];
                        string surname = memberParts[1].Split('-')[0].Trim(); // Get the surname before the delimiter

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            // Query to get additional details for the selected member
                            string query = "SELECT [Join Date], [Expiry Date] FROM [Founding Members] WHERE [First Name] = @FirstName AND [Surname] = @Surname";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@FirstName", firstName);
                                command.Parameters.AddWithValue("@Surname", surname);

                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        // Format join and expiry dates
                                        string joinDate = reader["Join Date"] != DBNull.Value ? Convert.ToDateTime(reader["Join Date"]).ToShortDateString() : "N/A";
                                        string expiryDate = reader["Expiry Date"] != DBNull.Value ? Convert.ToDateTime(reader["Expiry Date"]).ToShortDateString() : "N/A";

                                        // Show member details in a message box
                                        MessageBox.Show($"Join Date: {joinDate}\nExpiry Date: {expiryDate}",
                                            "Member Details",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No details found for the selected member.",
                                            "Information",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to parse the selected member's details.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminDashboard f2 = new AdminDashboard();
            f2.Show();
            Visible = false;
        }

        private void ToggleSortButton_Click_1(object sender, EventArgs e)
        {
            // Toggle the sorting order and reload data
            isAlphabetical = !isAlphabetical;
            LoadData();

            // Update the button text to reflect the current sort order
            Button button = sender as Button;
            if (button != null)
            {
                button.Text = isAlphabetical ? "Sort: Alphabetical" : "Sort: Original";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Add a new member by asking the user for details
            try
            {
                string firstName = Prompt.ShowDialog("Enter First Name:", "Add Member");
                string surname = Prompt.ShowDialog("Enter Surname:", "Add Member");
                string membershipStatus = Prompt.ShowDialog("Enter Membership Status:", "Add Member");

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(membershipStatus))
                {
                    MessageBox.Show("All fields must be filled to add a member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO [Founding Members] ([First Name], [Surname], [Membership Status]) VALUES (@FirstName, @Surname, @MembershipStatus)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@MembershipStatus", membershipStatus);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Member added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Refresh the list
                        }
                        else
                        {
                            MessageBox.Show("Failed to add member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Remove a member based on user input
            try
            {
                string firstName = Prompt.ShowDialog("Enter First Name of the Member to Remove:", "Remove Member");
                string surname = Prompt.ShowDialog("Enter Surname of the Member to Remove:", "Remove Member");

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(surname))
                {
                    MessageBox.Show("First Name and Surname must be provided to remove a member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM [Founding Members] WHERE [First Name] = @FirstName AND [Surname] = @Surname";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@Surname", surname);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Member removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Refresh the list
                        }
                        else
                        {
                            MessageBox.Show("No matching member found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static class Prompt
        {

            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 400,
                    Height = 200,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 340 };
                TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
                Button confirmation = new Button() { Text = "OK", Left = 270, Width = 90, Top = 100, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : string.Empty;
            }
        }
    }
}
