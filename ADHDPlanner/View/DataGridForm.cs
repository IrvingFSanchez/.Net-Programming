using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ADHDPlanner.Model;

namespace ADHDPlanner.View
{
    public partial class DataGridForm : Form
    {
        // We'll store a reference to the SAME list from MainForm
        // A BindingList to allow editing in the DataGridView
        private BindingList<ADHDEvent> bindingList;

        public DataGridForm(List<ADHDEvent> events)
        {
            InitializeComponent();

            // Convert your List<ADHDEvent> to a BindingList so changes are tracked
            bindingList = new BindingList<ADHDEvent>(events);

            // Set the DataSource for the DataGridView
            dataGridView1.DataSource = bindingList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // If you want to accept changes, just set DialogResult = OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
