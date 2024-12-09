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
        public void SetFullName(string fullName)
        {
            FullNameProfileTxt.Text = $"Full Name - {fullName}";
        }

        public void SetEmailAddress(string emailAddress)
        {
            EmailProfileTxt.Text = $"Email - {emailAddress}";
        }

        public void SetMembershipType(string membershipType)
        {
            memberProfileTxt.Text = $"Membership - {membershipType}";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPasswordForm = new ForgotPassword();

            forgotPasswordForm.Show();

            this.Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            AdminDashboard events = new AdminDashboard();
         

            this.Hide();
            events.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void memberProfileTxt_TextChanged(object sender, EventArgs e)
        {
            
        }



    }

}
