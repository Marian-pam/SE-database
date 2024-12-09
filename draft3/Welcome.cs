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
            InitializeComponent(); // Sets up the form and all its controls
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This event is triggered when the form finishes loading.
            // Right now, there's nothing happening here, but you can use it for initialization tasks.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // When the user clicks "Login," open the Login form.
            login f2 = new login(); // Create an instance of the Login form.
            f2.Show(); // Show the Login form to the user.
            Visible = false; // Hide the Welcome form but don’t close it completely.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // When the user clicks "Membership," open the Membership form.
            Membership f2 = new Membership(); // Create an instance of the Membership form.
            f2.Show(); // Show the Membership form to the user.
            Visible = false; // Hide the Welcome form but don’t close it completely.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // This event is triggered whenever the text inside textBox1 changes.
            // Currently, there's no functionality here, but you can handle user input if needed.
        }
    }
}
