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
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Events button
        {
            Events events = new Events();
            this.Hide();
            events.Show();
        }

        private void button2_Click(object sender, EventArgs e) // Placeholder (Events Database)
        {
            // Functionality not implemented
            Members_Database_Page f2 = new Members_Database_Page();
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

        private void AdminDashboard_Load(object sender, EventArgs e) // Settings (Load Dashboard)
        {
            // Functionality not implemented
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserSettings f2 = new UserSettings();
            f2.Show();
            Visible = false;
        }
    }
}

