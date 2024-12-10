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
    public partial class ChatsPage : Form
    {
        public ChatsPage()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminDashboard events = new AdminDashboard();
            this.Hide();
            events.Show();
        }

        private void ChatsPage_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FullNameProfileTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
