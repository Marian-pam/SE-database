namespace draft3
{
    partial class Events
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
            this.components = new System.ComponentModel.Container();
            this.togetherCultureDataSet = new draft3.togetherCultureDataSet();
            this.eventsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eventsTableAdapter = new draft3.togetherCultureDataSetTableAdapters.EventsTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.attendeeStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.togetherCultureDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // togetherCultureDataSet
            // 
            this.togetherCultureDataSet.DataSetName = "togetherCultureDataSet";
            this.togetherCultureDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eventsBindingSource
            // 
            this.eventsBindingSource.DataMember = "Events";
            this.eventsBindingSource.DataSource = this.togetherCultureDataSet;
            // 
            // eventsTableAdapter
            // 
            this.eventsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attendeeStatusDataGridViewTextBoxColumn,
            this.eventNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.eventsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(335, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // attendeeStatusDataGridViewTextBoxColumn
            // 
            this.attendeeStatusDataGridViewTextBoxColumn.DataPropertyName = "Attendee Status";
            this.attendeeStatusDataGridViewTextBoxColumn.HeaderText = "Attendee Status";
            this.attendeeStatusDataGridViewTextBoxColumn.Name = "attendeeStatusDataGridViewTextBoxColumn";
            // 
            // eventNameDataGridViewTextBoxColumn
            // 
            this.eventNameDataGridViewTextBoxColumn.DataPropertyName = "Event Name";
            this.eventNameDataGridViewTextBoxColumn.HeaderText = "Event Name";
            this.eventNameDataGridViewTextBoxColumn.Name = "eventNameDataGridViewTextBoxColumn";
            // 
            // Events
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 467);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Events";
            this.Text = "Events";
            this.Load += new System.EventHandler(this.Events_Load);
            ((System.ComponentModel.ISupportInitialize)(this.togetherCultureDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private togetherCultureDataSet togetherCultureDataSet;
        private System.Windows.Forms.BindingSource eventsBindingSource;
        private togetherCultureDataSetTableAdapters.EventsTableAdapter eventsTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn attendeeStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventNameDataGridViewTextBoxColumn;
    }
}