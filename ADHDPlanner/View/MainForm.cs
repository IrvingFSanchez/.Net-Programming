/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: A task manager for individuals with ADHD (or executive functioning challenges) that helps users
manage tasks, prioritize them, and track deadlines, now with image attachment, a data grid view,
and JSON save/load functionality.
*/

/*
Note: We have integrated previous console-based ADHD planner logic into a Windows Forms MVC approach.
This file, MainForm.cs, serves as the main View that references our model (ADHDEvent) and
controller (ADHDController). We have added comment blocks around new features like image
handling, data grid usage, and JSON-based save/load.
*/

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ADHDPlanner.Controller;
using ADHDPlanner.Model;
using System.Collections.Generic;
using System.Text.Json;

namespace ADHDPlanner.View
{
    public partial class MainForm : Form
    {
        private ADHDController controller;

        /*
         * Constructor to set up the form, wire up button click events,
         * and instantiate our controller.
         */
        public MainForm()
        {
            InitializeComponent();

            /*---+---+---+--Start of Event Wiring Block---+---+---+--*/
            // In this block, we wire up our button click events (Add/Edit, MarkCompleted, etc.)
            // so that each control calls the corresponding method in this class.
            this.btnAddEdit.Click += btnAddEdit_Click;
            this.btnMarkCompleted.Click += btnMarkCompleted_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnExit.Click += btnExit_Click;
            this.btnBrowseImage.Click += btnBrowseImage_Click;
            this.btnShowGrid.Click += btnShowGrid_Click;
            /*---+---+---+--End of Event Wiring Block---+---+---+--*/

            /*---+---+---+--Start of Controller Instantiation Block---+---+---+--*/
            // In this block, we create an instance of our ADHDController, which manages ADHDEvents
            // stored in a list. The controller handles add/edit/delete logic for tasks.
            controller = new ADHDController();
            /*---+---+---+--End of Controller Instantiation Block---+---+---+--*/
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Populate the priority combo box
            comboPriority.Items.Add("High");
            comboPriority.Items.Add("Medium");
            comboPriority.Items.Add("Low");
            comboPriority.SelectedIndex = 1; // Default to Medium

            UpdateDisplay();
        }

        /*
         * ============================================================
         * ================  MENU HANDLERS SECTION  ==================
         * ============================================================
         */

        /*---+---+---+--Start of Exit Menu Block---+---+---+--*/
        // When the user chooses File -> Exit or presses Ctrl+X, we prompt for confirmation, then close the application.
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to quit?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        /*---+---+---+--End of Exit Menu Block---+---+---+--*/


        /*---+---+---+--Start of About Menu Block---+---+---+--*/
        // Show an About dialog describing the application and its features.
        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "ADHD Planner (v2.0)\n" +
                "Author: Irving Sanchez\n" +
                "© 2025\n\n" +
                "This Windows Forms application assists individuals with ADHD or difficulty with executive functioning " +
                "(or anyone looking to stay organized) in managing tasks, setting priorities, and tracking deadlines.\n\n" +
                "Features include:\n" +
                "- Saving and loading tasks in JSON format\n" +
                "- Attaching images to tasks\n" +
                "- Marking tasks as ‘Urgent’\n" +
                "- Tracking task completion status and overall progress\n\n" +
                "Thank you for using ADHD Planner!",
                "About ADHD Planner",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        /*---+---+---+--End of About Menu Block---+---+---+--*/


        /*---+---+---+--Start of Save Menu Block---+---+---+--*/
        // File -> Save. We serialize our list of ADHDEvents to JSON and store them in a user-chosen file.
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON file|*.json|All files|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Get all tasks from the controller
                        var allTasks = controller.GetAllEvents();

                        // Serialize to JSON
                        string json = JsonSerializer.Serialize(allTasks);

                        // Write the JSON to the selected file
                        File.WriteAllText(sfd.FileName, json);

                        MessageBox.Show("File saved successfully!", "Success");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error");
                    }
                }
            }
        }
        /*---+---+---+--End of Save Menu Block---+---+---+--*/


        /*---+---+---+--Start of Load Menu Block---+---+---+--*/
        // File -> Load. We deserialize a JSON file back into a list of ADHDEvents, replacing the current list in the controller.
        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON file|*.json|All files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Read file contents
                        string json = File.ReadAllText(ofd.FileName);

                        // Deserialize into List<ADHDEvent>
                        var loaded = JsonSerializer.Deserialize<List<ADHDEvent>>(json);

                        // If we got data, replace existing events
                        if (loaded != null)
                        {
                            controller.ReplaceAllEvents(loaded);
                            MessageBox.Show("File loaded successfully!", "Success");
                            UpdateDisplay();
                        }
                        else
                        {
                            MessageBox.Show("Unable to deserialize file.", "Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading file: {ex.Message}", "Error");
                    }
                }
            }
        }
        /*---+---+---+--End of Load Menu Block---+---+---+--*/


        /*
         * ============================================================
         * ================= BUTTON HANDLERS SECTION ==================
         * ============================================================
         */

        /*---+---+---+--Start of Add/Edit Block---+---+---+--*/
        // This block handles the Add/Edit button click.
        // If the user enters a new task name, we create a new event.
        // If the task name already exists, we update the existing event (including image path).
        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text.Trim();
            DateTime dueDate = dateTimePickerDueDate.Value;
            string priority = comboPriority.SelectedItem?.ToString() ?? "Medium";
            bool isUrgent = chkIsUrgent.Checked;
            string? imagePath = string.IsNullOrWhiteSpace(txtImagePath.Text) ? null : txtImagePath.Text;

            // Basic validation: Ensure we have a task name
            if (string.IsNullOrWhiteSpace(taskName))
            {
                MessageBox.Show("Please enter a task name.", "Error");
                return;
            }

            // Check if an event with the same name already exists
            var existing = controller.GetAllEvents()
                .FirstOrDefault(t => t.TaskName.Equals(taskName, StringComparison.OrdinalIgnoreCase));

            if (existing != null)
            {
                // If it already exists, we ask if user wants to rename the task name
                var result = MessageBox.Show(
                    $"Task '{taskName}' already exists. Do you want to update its name?",
                    "Edit Existing Task Name",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // We always update due date, priority, urgent, image path
                existing.DueDate = dueDate;
                existing.PriorityLevel = priority;
                existing.IsUrgent = isUrgent;
                existing.ImagePath = imagePath;

                if (result == DialogResult.Yes)
                {
                    // If yes, we rename it too (in this example, user re-enters the same name or a new one)
                    existing.TaskName = taskName;
                    MessageBox.Show("Task name and details updated successfully!", "Success");
                }
                else
                {
                    MessageBox.Show("Task name was not changed. Other details (including image) were updated.", "Info");
                }
            }
            else
            {
                // It's a brand-new task
                try
                {
                    controller.AddEvent(taskName, dueDate, priority, isUrgent, imagePath);
                    MessageBox.Show("New task added successfully!", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

            // Clear the UI fields after adding/editing
            txtTaskName.Clear();
            dateTimePickerDueDate.Value = DateTime.Now.AddDays(1);
            comboPriority.SelectedIndex = 1; // Medium
            chkIsUrgent.Checked = false;
            txtImagePath.Clear();
            pictureBoxTaskImage.Image = null;

            UpdateDisplay();
        }
        /*---+---+---+--End of Add/Edit Block---+---+---+--*/


        /*---+---+---+--Start of MarkCompleted Block---+---+---+--*/
        // This block handles the Mark Completed button, toggling IsCompleted for the selected task.
        private void btnMarkCompleted_Click(object sender, EventArgs e)
        {
            string selectedTask = comboExistingTasks.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(selectedTask))
            {
                MessageBox.Show("Please select a task to mark as completed.", "Error");
                return;
            }

            try
            {
                controller.MarkAsCompleted(selectedTask);
                MessageBox.Show($"Task '{selectedTask}' marked as completed.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            UpdateDisplay();
        }
        /*---+---+---+--End of MarkCompleted Block---+---+---+--*/


        /*---+---+---+--Start of Delete Block---+---+---+--*/
        // This block handles the Delete button, removing the selected task from the list.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectedTask = comboExistingTasks.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(selectedTask))
            {
                MessageBox.Show("Please select a task to delete.", "Error");
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete '{selectedTask}'?",
                "Delete Task",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    controller.DeleteEvent(selectedTask);
                    MessageBox.Show("Task deleted successfully!", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                UpdateDisplay();
            }
        }
        /*---+---+---+--End of Delete Block---+---+---+--*/


        /*---+---+---+--Start of Exit Button Block---+---+---+--*/
        // Handles the Exit button (separate from File -> Exit).
        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to quit?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        /*---+---+---+--End of Exit Button Block---+---+---+--*/


        /*---+---+---+--Start of Combo Box SelectedIndexChanged Block---+---+---+--*/
        // When the user picks a task from the combo box, display its data in the text fields, checkbox, and image box.
        private void comboExistingTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTask = comboExistingTasks.SelectedItem?.ToString() ?? "";
            if (!string.IsNullOrEmpty(selectedTask))
            {
                var ev = controller.GetAllEvents()
                    .FirstOrDefault(t => t.TaskName.Equals(selectedTask, StringComparison.OrdinalIgnoreCase));
                if (ev != null)
                {
                    txtTaskName.Text = ev.TaskName;
                    dateTimePickerDueDate.Value = ev.DueDate;
                    chkIsUrgent.Checked = ev.IsUrgent;

                    // Priority
                    if (ev.PriorityLevel.Equals("High", StringComparison.OrdinalIgnoreCase))
                        comboPriority.SelectedIndex = 0;
                    else if (ev.PriorityLevel.Equals("Medium", StringComparison.OrdinalIgnoreCase))
                        comboPriority.SelectedIndex = 1;
                    else
                        comboPriority.SelectedIndex = 2; // Low

                    // Show image if path is valid
                    if (!string.IsNullOrEmpty(ev.ImagePath) && File.Exists(ev.ImagePath))
                    {
                        txtImagePath.Text = ev.ImagePath;
                        pictureBoxTaskImage.Image = System.Drawing.Image.FromFile(ev.ImagePath);
                    }
                    else
                    {
                        txtImagePath.Clear();
                        pictureBoxTaskImage.Image = null;
                    }
                }
            }
        }
        /*---+---+---+--End of Combo Box SelectedIndexChanged Block---+---+---+--*/


        /*---+---+---+--Start of Browse Image Block---+---+---+--*/
        // This block handles the Browse Image button, letting the user pick an image file
        // which updates txtImagePath and pictureBoxTaskImage immediately.
        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = ofd.FileName;
                    pictureBoxTaskImage.Image = System.Drawing.Image.FromFile(ofd.FileName);
                }
            }
        }
        /*---+---+---+--End of Browse Image Block---+---+---+--*/


        /*---+---+---+--Start of Data Grid Block---+---+---+--*/
        // This block handles the Show Grid button to open a modal form (DataGridForm) for editing tasks in a table format.
        private void btnShowGrid_Click(object sender, EventArgs e)
        {
            List<ADHDEvent> events = controller.GetAllEvents();

            using (var gridForm = new DataGridForm(events))
            {
                DialogResult result = gridForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    UpdateDisplay();
                }
            }
        }
        /*---+---+---+--End of Data Grid Block---+---+---+--*/


        /*
         * ============================================================
         * ================== UPDATE DISPLAY SECTION ==================
         * ============================================================
         */

        /*---+---+---+--Start of UpdateDisplay Block---+---+---+--*/
        // This block refreshes the UI after any Add/Edit/Delete/Load operations,
        // populating the combo box and multiline textbox with the latest tasks, and
        // updating the progress label with the completion percentage.
        private void UpdateDisplay()
        {
            txtAllTasks.Clear();
            comboExistingTasks.Items.Clear();

            var allTasks = controller.GetAllEvents();
            foreach (var t in allTasks)
            {
                txtAllTasks.AppendText(t.ToString());
                txtAllTasks.AppendText(Environment.NewLine + new string('-', 40) + Environment.NewLine);

                comboExistingTasks.Items.Add(t.TaskName);
            }

            double progress = controller.GetCompletionPercentage();
            lblProgress.Text = $"Progress: {progress:F1}%";
        }
        /*---+---+---+--End of UpdateDisplay Block---+---+---+--*/
    }
}
