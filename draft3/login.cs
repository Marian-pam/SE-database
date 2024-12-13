using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace draft3
{
    public partial class login : Form
    {
        // Database connection string
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\togetherCulture.mdf;Integrated Security=True";

        public login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void PasswordTxtBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }

        private void ForgotPassword_Click(object sender, EventArgs e)
        {
            
            ForgotPassword f2 = new ForgotPassword();
            f2.Show();
            Visible = false;
        }

        private void EmailTxtBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Login button logic
            string email = EmailTxtBox.Text.Trim();
            string password = PasswordTxtBox.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(1) FROM subscriberInfo WHERE emailid = @Email AND password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 1)
                        {
                            MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AdminDashboard adminDashboard = new AdminDashboard();
                            this.Hide();
                            adminDashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterBtn_Click_1(object sender, EventArgs e)
        {
            // Redirect to registration form if applicable
            createAccount f2 = new createAccount();
            f2.Show();
            Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Welcome f2 = new Welcome();
            f2.Show();
            Visible = false;
        }
    }
}
