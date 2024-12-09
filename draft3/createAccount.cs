using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace draft3
{
    public partial class createAccount : Form
    {
        public createAccount()
        {
            InitializeComponent();
        }

        private void createAccount_Load(object sender, EventArgs e)
        {
            // You can add any initialization code here if needed
        }

        private void textBox2lastName(object sender, EventArgs e)
        {
            // Event handler for lastName textbox
        }

        private void textBox4firstName(object sender, EventArgs e)
        {
            // Event handler for firstName textbox
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Panel paint event handler
        }

        private void textBox1Password2(object sender, EventArgs e)
        {
            // Event handler for Password2 textbox
        }

        private void textBox6Password(object sender, EventArgs e)
        {
            // Event handler for Password textbox
        }

        private void button7_Click(object sender, EventArgs e)
        {
            login f2 = new login();
            f2.Show();
            Visible = false;
        }

        private void textBox5Email(object sender, EventArgs e)
        {
            // Event handler for Email textbox
        }

        private void button1signUp_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Safwan\source\repos\SE-database\draft3bang\draft3\togetherCulture.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO subscriberInfo (firstName, lastName, emailId, password, dob) VALUES (@FirstName, @LastName, @Email, @Password, @DOB)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", textBox4.Text);
                    command.Parameters.AddWithValue("@LastName", textBox2.Text);
                    command.Parameters.AddWithValue("@Email", textBox5.Text);
                    command.Parameters.AddWithValue("@Password", textBox6.Text);

                    // Parse the DOB string to DateTime
                    if (DateTime.TryParse(textBox3DOB.Text, out DateTime dob))
                    {
                        command.Parameters.AddWithValue("@DOB", dob);
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format for DOB. Please use a valid date format.");
                        return;
                    }

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Account created successfully!");
                            // Optionally, you can clear the textboxes or navigate to another form here
                        }
                        else
                        {
                            MessageBox.Show("Failed to create account. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }
    }
}