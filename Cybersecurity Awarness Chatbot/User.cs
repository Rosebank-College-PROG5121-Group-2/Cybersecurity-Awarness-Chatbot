using System;

namespace CybersecurityChatbot
{
    // Class to store and manage user session data
    public class User
    {
        // Property to store the user's name across the session
        public string Name { get; set; }

        // Method to prompt user and store input
        public void GetUserName()
        {
            Console.Write("\n[SYSTEM] Please enter your username for authentication: ");
            Name = Console.ReadLine();

            // Provides immediate feedback to the user
            Console.WriteLine($"[AUTH] Access granted. Welcome, {Name}.");
        }
    }
}
//