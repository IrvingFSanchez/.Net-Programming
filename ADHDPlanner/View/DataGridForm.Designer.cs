using System;
using System.Windows.Forms;
using System.Drawing;

namespace ADHDPlanner.View
{
    partial class DataGridForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.dataGridView1 = new DataGridView();
            this.btnClose = new Button();

            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.Location = new Point(20, 20);
            this.dataGridView1.Size = new Size(600, 300);
            this.dataGridView1.AllowUserToAddRows = true;    // Let user add new tasks
            this.dataGridView1.AllowUserToDeleteRows = true; // Let user delete tasks
            this.dataGridView1.AutoGenerateColumns = true;   // Auto columns from properties
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // btnClose
            this.btnClose.Text = "Close";
            this.btnClose.Location = new Point(20, 330);
            this.btnClose.Size = new Size(80, 30);
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // DataGridForm
            this.ClientSize = new Size(640, 380);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClose);
            this.Name = "DataGridForm";
            this.Text = "Edit Tasks in a Grid";
            this.ResumeLayout(false);
        }
    }
}
