namespace draft3
{
    partial class Members_Database_Page
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button7 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ToggleSortButton = new System.Windows.Forms.Button();
            this.AddMembers = new System.Windows.Forms.Button();
            this.RemoveMembers = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Maroon;
            this.button7.Font = new System.Drawing.Font("Arial", 16F);
            this.button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button7.Location = new System.Drawing.Point(695, 400);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(93, 38);
            this.button7.TabIndex = 3;
            this.button7.Text = "Return ";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 473);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::draft3.Properties.Resources.Screenshot_2024_12_01_200551;
            this.pictureBox1.Location = new System.Drawing.Point(10, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(197, 114);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(433, 147);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ToggleSortButton
            // 
            this.ToggleSortButton.Location = new System.Drawing.Point(634, 114);
            this.ToggleSortButton.Name = "ToggleSortButton";
            this.ToggleSortButton.Size = new System.Drawing.Size(103, 23);
            this.ToggleSortButton.TabIndex = 6;
            this.ToggleSortButton.Text = "Sort: Original";
            this.ToggleSortButton.UseVisualStyleBackColor = true;
            this.ToggleSortButton.Click += new System.EventHandler(this.ToggleSortButton_Click_1);
            // 
            // AddMembers
            // 
            this.AddMembers.Location = new System.Drawing.Point(634, 152);
            this.AddMembers.Name = "AddMembers";
            this.AddMembers.Size = new System.Drawing.Size(103, 23);
            this.AddMembers.TabIndex = 7;
            this.AddMembers.Text = "Add members";
            this.AddMembers.UseVisualStyleBackColor = true;
            this.AddMembers.Click += new System.EventHandler(this.button1_Click);
            // 
            // RemoveMembers
            // 
            this.RemoveMembers.Location = new System.Drawing.Point(634, 192);
            this.RemoveMembers.Name = "RemoveMembers";
            this.RemoveMembers.Size = new System.Drawing.Size(103, 23);
            this.RemoveMembers.TabIndex = 8;
            this.RemoveMembers.Text = "Remove members";
            this.RemoveMembers.UseVisualStyleBackColor = true;
            this.RemoveMembers.Click += new System.EventHandler(this.button2_Click);
            // 
            // Members_Database_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RemoveMembers);
            this.Controls.Add(this.AddMembers);
            this.Controls.Add(this.ToggleSortButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button7);
            this.Name = "Members_Database_Page";
            this.Text = "Members_Database_Page";
            this.Load += new System.EventHandler(this.Members_Database_Page_Load_1);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button ToggleSortButton;
        private System.Windows.Forms.Button AddMembers;
        private System.Windows.Forms.Button RemoveMembers;
    }
}