using System;
using System.Collections.Generic;
using System.Linq;

using task_manager.model;
using task_manager.repository;
using Task = task_manager.model.Task;

namespace task_manager.service
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        private Dictionary<string, List<Task>> _allTasks;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
            _allTasks = _repository.LoadAllTasks();
        }


        public void AddTask(DateTime targetDate, string taskName, short taskPriority)
        {
            string datekey = targetDate.ToString("yyyy-MM-dd");

            if(!_allTasks.ContainsKey(datekey))
            {
                _allTasks[datekey] = new List<Task>();
            }

            int newId = 1;
            if (_allTasks[datekey].Any()) //LINQ to check if there are existing tasks for the date
            {
                newId = _allTasks[datekey].Max(t => t.TaskId) + 1; // Get the max TaskId and increment by 1
            }
            

            Task newTask = new Task(newId, taskName, taskPriority);
            _allTasks[datekey].Add(newTask);
            _repository.SaveAllTasks(_allTasks);
            Console.WriteLine("Task added successfully!");
        }

        public void PrintTasks()
        {
            Console.WriteLine("ALL TASKS:");
            foreach(var datePair in _allTasks)
            {
                Console.WriteLine($"\nDate: {datePair.Key}");
                foreach(var task in datePair.Value)
                {
                    Console.WriteLine($"ID: {task.TaskId} | Name: {task.TaskName} | Priority: {task.TaskPriority} | Completed: {task.IsCompleted}");
                }
            }
            Console.WriteLine("End of tasks list.");
        }


    }
}