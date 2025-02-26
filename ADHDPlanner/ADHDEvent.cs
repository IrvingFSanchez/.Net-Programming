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

namespace ADHDPlanner
{
    public class ADHDEvent
    {
        //Properties of the class
        public string TaskName{get; set;}
        public DateTime DueDate{get; set;}
        public string PriorityLevel{get; set;}
        public bool IsCompleted{get; set;}
        // Cacluated property to determine the time remaining for the task
        public TimeSpan TimeRemaining
        {
            get { return DueDate - DateTime.Now; }
        }
        // Default constructor
        public ADHDEvent()
        {
            TaskName = "Untitled Task";
            DueDate = DateTime.Now.AddDays(1);
            PriorityLevel = "Medium";
            IsCompleted = false;
        }

        public ADHDEvent(string taskName, DateTime dueDate, string priorityLevel)
        {
            TaskName = taskName;
            DueDate = dueDate;
            PriorityLevel = priorityLevel;
            IsCompleted = false;
        }

        // This overrides string ToString()
        public override string ToString()
        {
            string status = IsCompleted ? "Completed" : "Pending";
            return  $"Task: {TaskName}\n" +
                    $"Due Date: {DueDate.ToString("MM/dd/yyyy hh:mm tt")}\n" +
                    $"Priority: {PriorityLevel}\n" +
                    $"Status: {status}\n" +
                    $"Time Remaining: {TimeRemaining.Days} days, {TimeRemaining.Hours} hours, {TimeRemaining.Minutes} minutes\n";
        }
    }
}