﻿using System;
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
    public partial class Digital_Content_Page : Form
    {
        public Digital_Content_Page()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminDashboard events = new AdminDashboard();
            this.Hide();
            events.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
