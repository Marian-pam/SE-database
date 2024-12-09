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
    public partial class AdminDashboard : Form
    {
        private string _fullName;
        private string _email;
        private string _membershipType;

        public AdminDashboard(string fullName, string email, string membershipType)
        {
            InitializeComponent();

            _fullName = fullName;
            _email = email;
            _membershipType = membershipType;
        }

        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e) // When the dashboard loads
        {
            // Set the labels in AdminDashboard
            fullNameLabel.Text = $"Full Name: {_fullName}";
            emailLabel.Text = $"Email: {_email}";
            membershipLabel.Text = $"Membership Type: {_membershipType}";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserSettings userSettingsForm = new UserSettings();

          
            userSettingsForm.SetFullName(_fullName);
            userSettingsForm.SetEmailAddress(_email);
            userSettingsForm.SetMembershipType(_membershipType);

          
            userSettingsForm.Show();
            this.Hide(); 
        }


        public void SetUserDetails(string fullName, string email, string membershipType)
        {
            _fullName = fullName;
            _email = email;
            _membershipType = membershipType;
        }

       

        private void button1_Click(object sender, EventArgs e) // Events button
        {
            Events events = new Events();
            this.Hide();
            events.Show();
        }

        private void button2_Click(object sender, EventArgs e) // Placeholder (Events Database)
        {
            
            Members f2 = new Members();
            f2.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e) // Analytics button
        {
            AnalyticsPage f2 = new AnalyticsPage();
            f2.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e) // Membership button
        {
            Membership f2 = new Membership();
            f2.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e) // Chat button
        {
            ChatsPage f2 = new ChatsPage();
            f2.Show();
            Visible = false;
        }

        private void button7_Click(object sender, EventArgs e) // Returns back to the homepage button
        {
            Welcome f2 = new Welcome();
            f2.Show();
            Visible = false;
        }

        private void button8_Click(object sender, EventArgs e) // Digital Content button
        {
            Digital_Content_Page f2 = new Digital_Content_Page();
            f2.Show();
            Visible = false;
        }

        private void button9_Click(object sender, EventArgs e) // Interests button
        {
            Interests_Page f2 = new Interests_Page();
            f2.Show();
            Visible = false;
        }

        private void button10_Click(object sender, EventArgs e) // Documents button
        {
            Documents_Page f2 = new Documents_Page();
            f2.Show();
            Visible = false;
        }

        

        private void fullNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void membershipLabel_Click(object sender, EventArgs e)
        {

        }

        private void emailLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

