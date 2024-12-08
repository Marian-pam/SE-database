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
    public partial class Membership : Form
    {

        public Membership()
        {
            InitializeComponent();

            membershipSelect.Items.Add("Community");
            membershipSelect.Items.Add("Workspace");

            membershipSelect.SelectedIndexChanged += membershipSelect_SelectedIndexChanged;
        }

        private void PayNow_Click(object sender, EventArgs e)
        {
            string fullName = FullNameTxt.Text;
            string email = EmailAddressTxt.Text;
            string membershipType = membershipSelect.SelectedItem?.ToString() ?? "None";


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Month_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
      
        }

        private void membershipSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMembership = membershipSelect.SelectedItem.ToString();

            if (selectedMembership == "Community")
            {
                totalPrice.Text = "£18.50";
            }
            else if (selectedMembership == "Workspace")
            {
                totalPrice.Text = "£70.00";
            }
        }

        private void totalPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void payNow_Click_1(object sender, EventArgs e)
        {
            string fullName = FullNameTxt.Text;
            string email = EmailAddressTxt.Text;
            string membershipType = membershipSelect.SelectedItem?.ToString() ?? "None";
            string total = totalPrice.Text;

            if (string.IsNullOrEmpty(membershipType) || membershipType == "None")
            {
                MessageBox.Show("Please select a membership. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void linkLabelPAY_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Welcome f2 = new Welcome();
            f2.Show();
            Visible = false;
        }

        private void returnPayment_Click(object sender, EventArgs e)
        {
                
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
