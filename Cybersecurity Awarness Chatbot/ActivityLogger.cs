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

        public LogEntry(string actionText)
        {
            // Generates a readable timestamp format: e.g., "2026-06-25 20:45:12"
            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ActionText = actionText;
        }
    }

    // Handles reading and saving your logs to a local JSON file
    public class ActivityLogger
    {
        private readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity_log.json");

        // Appends a new action statement into the JSON array data
        public void LogAction(string actionDescription)
        {
            try
            {
                List<LogEntry> logs = LoadLogs();
                logs.Add(new LogEntry(actionDescription));

                // Serialize the list into readable, indented JSON syntax
                string json = JsonConvert.SerializeObject(logs, Formatting.Indented);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logging Error: {ex.Message}");
            }
        }

        // Returns a full historical list of all recorded log items
        public List<LogEntry> LoadLogs()
        {
            if (!File.Exists(FilePath)) return new List<LogEntry>();
            try
            {
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<LogEntry>>(json) ?? new List<LogEntry>();
            }
            catch { return new List<LogEntry>(); }
        }
    }
}