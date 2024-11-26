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
    public partial class Events : Form
    {
        public Events()
        {
            InitializeComponent();
        }

        private void Events_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'togetherCultureDataSet.Events' table. You can move, or remove it, as needed.
            this.eventsTableAdapter.Fill(this.togetherCultureDataSet.Events);



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
