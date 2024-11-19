using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;


namespace draft3
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            // This will be the redirect for the register or create acc page 
            //Register register = new Register();
            //register.show();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ForgotPassword_OnMouseHover(object sender, EventArgs e)
        {
            ForgotPassword.ForeColor = Color.Blue;
        }
        private void ForgotPassword_Click(object sender, EventArgs e)
        {
           ForgotPassword.ForeColor = Color.Purple;
           
            ForgotPassword f2 = new ForgotPassword();
            f2.Show();

            this.Hide();
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void EmailTxtBox_TextChanged(object sender, EventArgs e)
        {
            string email = EmailTxtBox.Text;
            if (IsValidEmail(email))
            {
                EmailTxtBox.ForeColor = Color.Black; // Color indicating valid input
            }
            else
            {
                EmailTxtBox.ForeColor = Color.Red; // Color indicating invalid input
            }
        }

        private bool IsValidEmail(string email)
        {
            
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void PasswordTxtBox_TextChanged(object sender, EventArgs e)
        {
            
        }

       
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }



        private bool ValidateCredentials(string email, string password)
        {
        // Connection string to your database (update with your actual path)
            string connectionString = @"Data Source=C:\Users\maria\source\repos\SE-database\4\draft3\togetherCulture.mdf;Integrated Security=True";

            string query = "SELECT COUNT(1) FROM subscriberInfo WHERE Email = @Email AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL Injection
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count == 1; // Returns true if a matching record is found
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}");
                    return false;
                }
            }
        }

       

        private void RegisterBtn_Click_1(object sender, EventArgs e)
        {
            createAccount f2 = new createAccount();
            f2.Show();

            this.Hide();
        }

        public void Login(string email, string password)
        {
            using (DatabaseHelper db = new DatabaseHelper())
            {
                try
                {
                    db.OpenConnection();

                    string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Email", email),
                        new SqlParameter("@Password", password)
                    };

                    DataTable result = db.ExecuteQuery(query, parameters);

                    if (result.Rows.Count > 0)
                    {
                        Console.WriteLine("Login successful!");
                        // Navigate to another page or perform an action
                    }
                    else
                    {
                        Console.WriteLine("Invalid email or password.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
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
    }
}
