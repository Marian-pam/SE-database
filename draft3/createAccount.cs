using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace draft3
{
    public partial class createAccount : Form
    {

        public createAccount()
        {
            InitializeComponent();
        }
        private void createAccount_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90); // Top-left corner
            path.AddArc(panel1.Width - 21, 0, 20, 20, 270, 90); // Top-right corner
            path.AddArc(panel1.Width - 21, panel1.Height - 21, 20, 20, 0, 90); // Bottom-right corner
            path.AddArc(0, panel1.Height - 21, 20, 20, 90, 90); // Bottom-left corner
            path.CloseAllFigures();
            panel1.Region = new Region(path);


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
