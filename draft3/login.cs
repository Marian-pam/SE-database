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

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxtBox.Text;
            string password = PasswordTxtBox.Text;

            if (ValidateCredentials(email, password))
            {
                MessageBox.Show("Login Successful!");
            }
            else
            {
                MessageBox.Show("Invalid Email or Password.");
            }
        }

        private bool ValidateCredentials(string email, string password)
        {
            // Replace with actual credential check (e.g., database or secure storage) this will be changed later on
            string storedEmail = "user@example.com";
            string storedPassword = "password123";

            return email == storedEmail && password == storedPassword;
        }

        private void RegisterBtn_Click_1(object sender, EventArgs e)
        {

        }
    }
}
