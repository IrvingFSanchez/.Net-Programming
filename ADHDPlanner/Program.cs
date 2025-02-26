/*
Name: Irving F. Sanchez
Course: CPSC-23000-001 .NET Programming 
School: Lewis University, Romeoville, IL
Purpose: A task manager for individuals with ADHD to help users manage tasks, prioritize, and track deadlines.
*/

/*
Note: This program is designed to assist users with ADHD (Attention Deficit Hyperactivity Disorder) in managing tasks, prioritizing, and tracking deadlines.
This program will include features like task prioritization, due date tracking, and filtering by priority.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Figgle;

namespace ADHDPlanner
{
    class Program
    {

        private const string SaveFilePath = "tasks.json"; // File to save tasks

        static void Main(string[] args)
        {


            List<ADHDEvent> tasks = new List<ADHDEvent>();


            /*---+---+---+--Start of Welcome Banner Block---+---+---+--*/
            // Display the welcome message in ASCII art

            // This will set the console text color to blue for the Banner
            Console.ForegroundColor = ConsoleColor.Green;
            // This will display the ASCII art banner
            Console.WriteLine(FiggleFonts.Standard.Render("=ADHD Planner="));
            // This will reset the console text color to the default color (white) so it doesn't affect the rest of the program
            Console.ResetColor();

            /*---+---+---+--End of Welcome Banner Block---+---+---+--*/



            /*---+---+---+--Start of Load Tasks Block---+---+---+--*/
            // This loads tasks from file (if the file exists)
            if (File.Exists(SaveFilePath))
            {
                string json = File.ReadAllText(SaveFilePath);
                tasks = JsonSerializer.Deserialize<List<ADHDEvent>>(json);
                Console.WriteLine("Tasks loaded successfully.");
            }
            else
            {
                Console.WriteLine("No saved tasks found. Starting with an empty list.");
            }
            /*---+---+---+--End of Load Tasks Block---+---+---+--*/



            /*---+---+---+--Start of Main Menu Block---+---+---+--*/
            // Main menu for adding, editing, deleting, and marking tasks
            while (true)
            {
                // This displays all tasks with color-coded priority
                Console.WriteLine("\nAll tasks:");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.Write($"[{i + 1}] ");
                    DisplayTaskWithColor(tasks[i]);
                }



                /*---+---+---+--Start of Progress Tracking Block---+---+---+--*/
                // This calculates and display progress
                int completedTasks = tasks.Count(t => t.IsCompleted);
                int totalTasks = tasks.Count;
                double completionPercentage = totalTasks > 0 ? (double)completedTasks / totalTasks * 100 : 0;

                Console.WriteLine($"\nProgress: {completedTasks}/{totalTasks} tasks completed ({completionPercentage:F1}%)");
                /*---+---+---+--End of Progress Tracking Block---+---+---+--*/



                // This asks the user how they want to interact with the program
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Add a new task");
                Console.WriteLine("2. Mark a task as completed");
                Console.WriteLine("3. Edit a task");
                Console.WriteLine("4. Delete a task");
                Console.WriteLine("5. Save and Exit");
                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Add a new task
                        AddTask(tasks);
                        break;

                    case "2": // Mark a task as completed
                        MarkTaskAsCompleted(tasks);
                        break;

                    case "3": // Edit a task
                        EditTask(tasks);
                        break;

                    case "4": // Delete a task
                        DeleteTask(tasks);
                        break;

                    case "5": // Save and Exit
                        SaveTasks(tasks);
                        Console.WriteLine("Tasks saved successfully. Exiting the program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            /*---+---+---+--End of Main Menu Block---+---+---+--*/
        }



        /*---+---+---+--Start of Save Tasks Block---+---+---+--*/
        // This is the method to save tasks to a file
        static void SaveTasks(List<ADHDEvent> tasks)
        {
            string json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(SaveFilePath, json);
        }
        /*---+---+---+--End of Save Tasks Block---+---+---+--*/



        /*---+---+---+--Start of DisplayTaskWithColor Block---+---+---+--*/
        // This is the method to display a task with color-coded priority
        static void DisplayTaskWithColor(ADHDEvent task)
        {
            // Set the console color based on priority
            switch (task.PriorityLevel.ToLower())
            {
                case "high":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "medium":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "low":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            // Display the task
            Console.WriteLine(task);

            // Reset the console color
            Console.ResetColor();
        }
        /*---+---+---+--End of DisplayTaskWithColor Block---+---+---+--*/



        /*---+---+---+--Start of AddTask Block---+---+---+--*/
        // This is the method to add a new task
        static void AddTask(List<ADHDEvent> tasks)
        {
            Console.WriteLine("\nEnter details for the new task:");

            // Task Name
            Console.Write("Task Name: ");
            string taskName = Console.ReadLine();

            // Due Date (with error handling)
            DateTime dueDate;
            while (true)
            {
                Console.Write("Due Date (MM/DD/YYYY HH:MM AM/PM): ");
                string dueDateInput = Console.ReadLine();
                if (DateTime.TryParse(dueDateInput, out dueDate))
                    break;
                else
                    Console.WriteLine("Invalid date format. Please try again.");
            }

            // Priority Level (with validation)
            string priorityLevel;
            while (true)
            {
                Console.Write("Priority Level (High, Medium, Low): ");
                priorityLevel = Console.ReadLine();
                if (new[] { "High", "Medium", "Low" }.Contains(priorityLevel, StringComparer.OrdinalIgnoreCase))
                    break;
                else
                    Console.WriteLine("Invalid priority level. Please enter High, Medium, or Low.");
            }

            // Create and add the task
            ADHDEvent newTask = new ADHDEvent(taskName, dueDate, priorityLevel);
            tasks.Add(newTask);
            Console.WriteLine("Task added successfully.");
        }
        /*---+---+---+--End of AddTask Block---+---+---+--*/



        /*---+---+---+--Start of MarkTaskAsCompleted Block---+---+---+--*/
        // This is the method to mark a task as completed
        static void MarkTaskAsCompleted(List<ADHDEvent> tasks)
        {
            Console.Write("Enter the task number to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks[taskNumber - 1].IsCompleted = true;
                Console.WriteLine($"Task '{tasks[taskNumber - 1].TaskName}' marked as completed.");
            }
            else
            {
                Console.WriteLine("Invalid task number. Please try again.");
            }
        }
        /*---+---+---+--End of MarkTaskAsCompleted Block---+---+---+--*/



        /*---+---+---+--Start of EditTask Block---+---+---+--*/
        // This is the method to edit a task
        static void EditTask(List<ADHDEvent> tasks)
        {
            Console.Write("Enter the task number to edit: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                ADHDEvent task = tasks[taskNumber - 1];

                Console.WriteLine($"Editing Task: {task.TaskName}");
                Console.Write("Enter new task name (or press Enter to keep current): ");
                string newTaskName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newTaskName))
                {
                    task.TaskName = newTaskName;
                }

                Console.Write("Enter new due date (MM/DD/YYYY HH:MM AM/PM) (or press Enter to keep current): ");
                string newDueDateInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDueDateInput) && DateTime.TryParse(newDueDateInput, out DateTime newDueDate))
                {
                    task.DueDate = newDueDate;
                }

                Console.Write("Enter new priority level (High, Medium, Low) (or press Enter to keep current): ");
                string newPriorityLevel = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPriorityLevel) && new[] { "High", "Medium", "Low" }.Contains(newPriorityLevel, StringComparer.OrdinalIgnoreCase))
                {
                    task.PriorityLevel = newPriorityLevel;
                }

                Console.WriteLine("Task updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid task number. Please try again.");
            }
        }
        /*---+---+---+--End of EditTask Block---+---+---+--*/



        /*---+---+---+--Start of DeleteTask Block---+---+---+--*/
        // This is the method to delete a task
        static void DeleteTask(List<ADHDEvent> tasks)
        {
            Console.Write("Enter the task number to delete: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                ADHDEvent task = tasks[taskNumber - 1];
                Console.WriteLine($"Are you sure you want to delete the task '{task.TaskName}'? (Y/N): ");
                string confirm = Console.ReadLine().ToUpper();
                if (confirm == "Y")
                {
                    tasks.RemoveAt(taskNumber - 1);
                    Console.WriteLine("Task deleted successfully.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task number. Please try again.");
            }
        }
        /*---+---+---+--End of DeleteTask Block---+---+---+--*/



    }
}

