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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {         
            login f2 = new login(); 
            f2.Show(); 
            Visible = false; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Membership f2 = new Membership(); 
            f2.Show();
            Visible = false; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
