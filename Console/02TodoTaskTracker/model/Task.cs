using System;

namespace task_manager.model
{
    public class Task
    {

        public int TaskId { get; set; }
        public string TaskName { get; set; }
        // public string TaskDescription { get; set; }
        public short TaskPriority { get; set; }
        public bool IsCompleted { get; set; }


        public Task(int taskId, string taskName, short taskPriority)
        {
            this.TaskId = taskId;
            this.TaskName = taskName;
            // this.TaskDescription = taskDescription;
            this.TaskPriority = taskPriority;
            this.IsCompleted = false;
        }


    }
}