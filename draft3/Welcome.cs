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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            // Trying to attach the event handler to the scroll bar

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login f2 = new login();
            f2.Show();
            Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
