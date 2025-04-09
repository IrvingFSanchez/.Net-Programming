using System;
using System.Collections.Generic;
using System.Linq;
using ADHDPlanner.Model;

namespace ADHDPlanner.Controller
{
    public class ADHDController
    {
        private readonly List<ADHDEvent> events;

        public ADHDController()
        {
            events = new List<ADHDEvent>();
        }

        public List<ADHDEvent> GetAllEvents()
        {
            // Return the list. In a more advanced setup, you might return a copy or a BindingList.
            return events;
        }

        public void AddEvent(string taskName, DateTime dueDate, string priorityLevel, bool isUrgent, string? imagePath)
        {
            // Check if event with same name already exists
            var existing = events.FirstOrDefault(e => e.TaskName.Equals(taskName, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
            {
                throw new InvalidOperationException("An event with that name already exists.");
            }

            var newEvent = new ADHDEvent(taskName, dueDate, priorityLevel)
            {
                IsUrgent = isUrgent,
                ImagePath = imagePath
            };
            events.Add(newEvent);
        }

        public void EditEvent(string originalTaskName, string newTaskName, DateTime? newDueDate, 
                            string newPriority, bool? isUrgent, string? imagePath)
        {
            var ev = events.FirstOrDefault(e => e.TaskName.Equals(originalTaskName, StringComparison.OrdinalIgnoreCase));
            if (ev == null)
                throw new InvalidOperationException("Event not found.");

            if (!string.IsNullOrWhiteSpace(newTaskName))
                ev.TaskName = newTaskName;
            if (newDueDate != null)
                ev.DueDate = newDueDate.Value;
            if (!string.IsNullOrWhiteSpace(newPriority))
                ev.PriorityLevel = newPriority;
            if (isUrgent != null)
                ev.IsUrgent = isUrgent.Value;
            if (!string.IsNullOrEmpty(imagePath))
                ev.ImagePath = imagePath;
        }

        public void DeleteEvent(string taskName)
        {
            var ev = events.FirstOrDefault(e => e.TaskName.Equals(taskName, StringComparison.OrdinalIgnoreCase));
            if (ev == null)
            {
                throw new InvalidOperationException("Event not found.");
            }
            events.Remove(ev);
        }

        public void MarkAsCompleted(string taskName)
        {
            var ev = events.FirstOrDefault(e => e.TaskName.Equals(taskName, StringComparison.OrdinalIgnoreCase));
            if (ev == null)
            {
                throw new InvalidOperationException("Event not found.");
            }
            ev.IsCompleted = true;
        }

        public double GetCompletionPercentage()
        {
            int completed = events.Count(e => e.IsCompleted);
            int total = events.Count;
            return (total == 0) ? 0.0 : (double)completed / total * 100.0;
        }

        // Replaces all objects the controller manages (used for loading)
        public void ReplaceAllEvents(List<ADHDEvent> newEvents)
        {
            events.Clear();
            events.AddRange(newEvents);
        }
    }
}
