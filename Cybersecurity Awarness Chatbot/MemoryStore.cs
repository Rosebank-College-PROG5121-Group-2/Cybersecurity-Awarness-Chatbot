using System.Collections.Generic;

namespace CybersecurityChatbot
{
    
    //Stores and recalls information about the user during the conversation.
    // Handles name, favourite topic, and any other key-value pairs.
    
    public class MemoryStore
    {
        // Stores the user's name
        public string UserName { get; set; } = string.Empty;

        // Stores the user's favourite cybersecurity topic
        public string FavouriteTopic { get; set; } = string.Empty;

        // General-purpose storage for any other key-value pairs
        private Dictionary<string, string> _memory = new Dictionary<string, string>();

        // Saves any key-value pair into memory 
      
        public void Store(string key, string value)
        {
            key = key.ToLower().Trim();

            if (_memory.ContainsKey(key))
                _memory[key] = value;
            else
                _memory.Add(key, value);
        }

        // Retrieves a stored value by its key. Returns empty string if not found.
        public string Recall(string key)
        {
            key = key.ToLower().Trim();
            return _memory.TryGetValue(key, out string value) ? value : string.Empty;
        }

        // Checks whether a specific key exists in memory.
       public bool Has(string key)
        {
            return _memory.ContainsKey(key.ToLower().Trim());
        }

      
        // Builds a personalised opening sentence using what we know about the user.
        public string GetPersonalisedOpener()
        {
            // Both name and topic are known
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(FavouriteTopic))
                return $"As someone interested in {FavouriteTopic}, {UserName}, here's what you should know: ";

            // Only name is known
            if (!string.IsNullOrEmpty(UserName))
                return $"{UserName}, here's something useful: ";

            // Only topic is known
            if (!string.IsNullOrEmpty(FavouriteTopic))
                return $"As someone interested in {FavouriteTopic}, here's what you should know: ";

            // Nothing known yet
            return string.Empty;
        }

        // Returns true if we know the user's name already.
        public bool HasName() => !string.IsNullOrEmpty(UserName);

        // Returns true if we know the user's favourite topic.
        public bool HasFavouriteTopic() => !string.IsNullOrEmpty(FavouriteTopic);
    }
}