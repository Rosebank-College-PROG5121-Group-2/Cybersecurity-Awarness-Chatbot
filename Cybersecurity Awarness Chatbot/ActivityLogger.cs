using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CybersecurityChatbotGUI
{
    // Individual log structure tracking a single action and when it occurred
    public class LogEntry
    {
        public string Timestamp { get; set; }
        public string ActionText { get; set; }

        public LogEntry()
        {
        }

        public LogEntry(string actionText)
        {
            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ActionText = actionText;
        }
    }

    // Handles reading and saving logs to a local JSON file
    public class ActivityLogger
    {
        private readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity_log.json");

        // Records a new action
        public void LogAction(string actionDescription)
        {
            try
            {
                List<LogEntry> logs = LoadLogs();
                logs.Add(new LogEntry(actionDescription));

                string json = JsonConvert.SerializeObject(logs, Formatting.Indented);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logging Error: {ex.Message}");
            }
        }

        // Loads all logs from the JSON file
        public List<LogEntry> LoadLogs()
        {
            if (!File.Exists(FilePath))
                return new List<LogEntry>();

            try
            {
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<LogEntry>>(json) ?? new List<LogEntry>();
            }
            catch
            {
                return new List<LogEntry>();
            }
        }

        // Returns all logs
        public List<LogEntry> GetLogs()
        {
            return LoadLogs();
        }
    }
}