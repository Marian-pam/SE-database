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
    }

}
