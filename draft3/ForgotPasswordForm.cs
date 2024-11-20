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
        // Triggered when the form is loaded
        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            // Initialization logic, if any
        }

        // Triggered when the label is clicked
        private void label1_Click(object sender, EventArgs e)
        {
            // Add label click functionality here, if needed
        }

        // Triggered when the MaskedTextBox rejects input
        private void EnterEmail_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            // Handle input rejection logic, if needed
        }

        private void SendEmail(string recipientEmail, string messageBody)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("SC1969@student.aru.ac.com", "19691969"),
                    EnableSsl = true
                };

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("SC1969@student.aru.com"),
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
                            string messageBody = "We have received a request to reset your password. Please contact us for further assistance.";
                            SendEmail(enteredEmail, messageBody);
                        }
                        else
                        {
                            MessageBox.Show("Email not found in our records.");
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
    }
}
