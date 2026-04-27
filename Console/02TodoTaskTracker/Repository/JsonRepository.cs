using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

using task_manager.model;
using Task = task_manager.model.Task;

namespace task_manager.repository
{
    public interface ITaskRepository
    {
        Dictionary<string, List<Task>> LoadAllTasks();

        void SaveAllTasks(Dictionary<string, List<Task>> tasks);


    }

    public class JsonRepository : ITaskRepository
    {
        private readonly string _filePath; // Path to the JSON file

        public JsonRepository(string filePath = "Tasks/tasks.json")
        {
            _filePath = filePath;
            InitializeFile();
        }

        private void InitializeFile()
        {
            string directory = Path.GetDirectoryName(_filePath);
            if(!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if(!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "{}");
            }
        }

        public Dictionary<string, List<Task>> LoadAllTasks()
        {
            string jsonString = File.ReadAllText(_filePath);

            if(string.IsNullOrEmpty(jsonString))
            {
                return new Dictionary<string, List<Task>>();
            }

            //Deserialization
            var tasks = JsonSerializer.Deserialize<Dictionary<string, List<Task>>>(jsonString);
            
            
            return tasks ?? new Dictionary<string, List<Task>>();
        }

        public void SaveAllTasks(Dictionary<string, List<Task>> AllTasks)
        {
            //Serialization(Human Readable)
            var options = new JsonSerializerOptions
            {
              WriteIndented = true  
            };

            string jsonString = JsonSerializer.Serialize(AllTasks, options);

            File.WriteAllText(_filePath, jsonString);
        }
    }
}