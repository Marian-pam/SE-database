using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace draft3
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void ForgotPassword_OnMouseHover(object sender, EventArgs e)
        {
            ForgotPassword.ForeColor = Color.Blue;
        }
        private void label4_Click(object sender, EventArgs e)
        {
            // Add relevant code here or leave empty if not required.
        }

        private void PasswordTxtBox_TextChanged(object sender, EventArgs e)
        {
            // Add relevant code here or leave empty if not required.
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Add relevant code here or leave empty if not required.
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Add relevant code here or leave empty if not required.
        }

        private void login_Load(object sender, EventArgs e)
        {
            // Add relevant code here or leave empty if not required.
        }

        private void ForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPassword.ForeColor = Color.Purple;

            ForgotPassword f2 = new ForgotPassword();
            f2.Show();

            this.Hide();
        }

        private void EmailTxtBox_TextChanged(object sender, EventArgs e)
        {
            string email = EmailTxtBox.Text;
            EmailTxtBox.ForeColor = IsValidEmail(email) ? Color.Black : Color.Red;
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower(); // Convert to a hex string
            }
        }


        private bool ValidateCredentials(string email, string password)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Safwan\source\repos\SE-database\draft3real\draft3\togetherCulture.mdf;Integrated Security=True";

            string query = "SELECT COUNT(1) FROM subscriberInfo WHERE emailId = @emailId AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL Injection
                        command.Parameters.AddWithValue("@emailId", email);
                        command.Parameters.AddWithValue("@password", HashPassword(password)); // If password is stored as a hash

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count == 1; // Returns true if a matching record is found
                    }
                }
                catch (Exception ex)
                {
                    // Log exception for debugging
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string email = EmailTxtBox.Text;
            string password = PasswordTxtBox.Text;

            if (ValidateCredentials(email, password))
            {
                MessageBox.Show("Login Successful!");
                UserDashboard f2 = new UserDashboard();
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Email or Password.");
            }
        }

        private void RegisterBtn_Click_1(object sender, EventArgs e)
        {
            createAccount f2 = new createAccount();
            f2.Show();
            this.Hide();
        }
    }
}
