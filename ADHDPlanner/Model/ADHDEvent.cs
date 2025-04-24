using System;

namespace ADHDPlanner.Model
{
    public class ADHDEvent
    {
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public string PriorityLevel { get; set; }
        public bool IsCompleted { get; set; }

        // New property for an associated image path
        public string? ImagePath { get; set; }

        // New property showing an additional aspect (e.g., "IsUrgent")
        public bool IsUrgent { get; set; }

        public TimeSpan TimeRemaining => DueDate - DateTime.Now;

        public ADHDEvent()
        {
            TaskName = "Untitled Task";
            DueDate = DateTime.Now.AddDays(1);
            PriorityLevel = "Medium";
            IsCompleted = false;
            ImagePath = null;
            IsUrgent = false;
        }

        public ADHDEvent(string taskName, DateTime dueDate, string priorityLevel)
        {
            TaskName = taskName;
            DueDate = dueDate;
            PriorityLevel = priorityLevel;
            IsCompleted = false;
            ImagePath = null;
            IsUrgent = false;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "Completed" : "Pending";
            return $@"Task: {TaskName}
                Due Date: {DueDate:MM/dd/yyyy hh:mm tt}
                Priority: {PriorityLevel}
                Status: {status}
                Is Urgent?: {(IsUrgent ? "Yes" : "No")}
                Time Remaining: {TimeRemaining.Days} days, {TimeRemaining.Hours} hours, {TimeRemaining.Minutes} minutes
                Image Path: {ImagePath ?? "No image selected"}
                ";
        }
    }
}
