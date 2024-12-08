using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace draft3
{
    public partial class ForgotPassword : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void EnterEmail_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void SendEmail(string recipientEmail, string messageBody)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("your-email@gmail.com", "your-email-password"),
                    EnableSsl = true
                };

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("your-email@gmail.com"),
                    Subject = "Password Recovery",
                    Body = messageBody,
                    IsBodyHtml = true
                };

                mail.To.Add(recipientEmail);
                smtpClient.Send(mail);

                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}");
            }
        }

        private void ValidateEmailAndSave(string enteredEmail, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Check if the email already exists
                    string queryCheck = "SELECT COUNT(1) FROM subscriberInfo WHERE emailId = @Email";
                    using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                    {
                        commandCheck.Parameters.AddWithValue("@Email", enteredEmail);
                        int count = Convert.ToInt32(commandCheck.ExecuteScalar());

                        if (count == 0)
                        {
                            // Insert new email and password into the table
                            string queryInsert = "INSERT INTO subscriberInfo (emailId, password) VALUES (@Email, @Password)";
                            using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                            {
                                commandInsert.Parameters.AddWithValue("@Email", enteredEmail);
                                commandInsert.Parameters.AddWithValue("@Password", password);
                                commandInsert.ExecuteNonQuery();

                                MessageBox.Show("Your credentials have been saved.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email already exists in the database.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}");
                }
            }
        }

        private void ForgotPasswordButton_Click(object sender, EventArgs e)
        {
            string enteredEmail = EnterEmail.Text;
            string password = "defaultPassword123"; // Replace with logic to securely generate a new password or take user input.

            if (!string.IsNullOrWhiteSpace(enteredEmail))
            {
                ValidateEmailAndSave(enteredEmail, password);

                // Optionally send the password via email
                string messageBody = $"Your account has been registered. Your password is: {password}";
                SendEmail(enteredEmail, messageBody);
            }
            else
            {
                MessageBox.Show("Please enter a valid email address.");
            }
        }

        private void EnterEmail_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            createAccount f2 = new createAccount();
            f2.Show();
            Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            login f2 = new login();
            f2.Show();
            Visible = false;
        }

        private void ForgotPassword_Load_1(object sender, EventArgs e)
        {
        }
    }
}

