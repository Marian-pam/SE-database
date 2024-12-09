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
    public partial class Documents_Page : Form
    {
        public Documents_Page()
        {
            InitializeComponent();
        }

        
        private void button12_Click(object sender, EventArgs e)
        {
            AdminDashboard events = new AdminDashboard();
            this.Hide();
            events.Show();
        }

        private void Documents_Page_Load(object sender, EventArgs e)
        {

        }
    }
}
