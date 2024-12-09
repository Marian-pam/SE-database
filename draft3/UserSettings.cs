using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace draft3
{
    public partial class UserSettings : Form
    {
        public UserSettings()
        {
            InitializeComponent();
        }
        public void SetMembershipType(string membershipType)
        {
            membershipProfileTxt.Text = $"Membership - {membershipType}";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        { }

        private void button2_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPasswordForm = new ForgotPassword();

            forgotPasswordForm.Show();

            this.Hide();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }
        public void SetFullName(string fullName)
        {
            fullNameTxt.Text = $"Full Name - {fullName}";
        }
        private void fullNameTxt_TextChanged(object sender, EventArgs e)
        { }
        public void SetEmailAddress(string emailAddress)
        {
            emailAddressTxt.Text = $"Email - {emailAddress}";
        }

        private void emailAddressTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminDashboard events = new AdminDashboard();
            this.Hide();
            events.Show();
        }
    }

}
