using System.Collections.Generic;

namespace CybersecurityChatbotGUI
{
    public class TaskManager
    {
        private readonly TaskStorageHelper storage;

        public TaskManager()
        {
            storage = new TaskStorageHelper();
        }

        public void AddTask(string title, string description, string reminder)
        {
            storage.AddTask(title, description, reminder);
        }

        public List<CyberTask> GetAllTasks()
        {
            return storage.LoadTasks();
        }
        public void MarkAsComplete(int taskId)
        {
            List<CyberTask> tasks = storage.LoadTasks();

            CyberTask task = tasks.Find(t => t.Id == taskId);

            if (task != null)
            {
                task.IsComplete = true;
                storage.SaveTasks(tasks);
            }
        }
        public void DeleteTask(int taskId)
        {
            List<CyberTask> tasks = storage.LoadTasks();

            tasks.RemoveAll(t => t.Id == taskId);

            storage.SaveTasks(tasks);
        }

    }
}