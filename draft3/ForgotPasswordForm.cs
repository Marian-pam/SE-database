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
            // maybe put input rejection in this 
        }

        private void SendEmail(string recipientEmail, string messageBody)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("", ""),
                    EnableSsl = true
                };

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(""),
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

        private void ValidateEmailAndSend(string enteredEmail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM subscriberInfo WHERE emailId = @emailId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@emailId", enteredEmail);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count == 1)
                        {
                            string messageBody = "Your request has been rejected. Please try again or request assistance.";
                            SendEmail(enteredEmail, messageBody);
                        }
                        else
                        {
                            MessageBox.Show("Email has not been found.");
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

            if (!string.IsNullOrWhiteSpace(enteredEmail))
            {
                ValidateEmailAndSend(enteredEmail);
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
