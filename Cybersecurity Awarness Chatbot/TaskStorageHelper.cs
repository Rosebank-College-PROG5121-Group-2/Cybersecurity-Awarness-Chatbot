using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CybersecurityChatbotGUI
{
    public class TaskStorageHelper
    {
        private const string FilePath = "tasks.json";

        public List<CyberTask> LoadTasks()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    return new List<CyberTask>();
                }

                string json = File.ReadAllText(FilePath);

                return JsonConvert.DeserializeObject<List<CyberTask>>(json)
                       ?? new List<CyberTask>();
            }
            catch
            {
                return new List<CyberTask>();
            }
        }
        public void SaveTasks(List<CyberTask> tasks)
        {
            try
            {
                string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);

                File.WriteAllText(FilePath, json);
            }
            catch
            {

            }
        }
        public void AddTask(string title, string description, string reminder)
        {
            List<CyberTask> tasks = LoadTasks();

            int newId = 1;

            if (tasks.Count > 0)
            {
                newId = tasks.Max(t => t.Id) + 1;
            }

            CyberTask task = new CyberTask
            {
                Id = newId,
                Title = title,
                Description = description,
                Reminder = reminder,
                IsComplete = false,
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
            };

            tasks.Add(task);

            SaveTasks(tasks);
        }
    }
}