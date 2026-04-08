using System;

namespace CybersecurityChatbot
{
    // The main execution class for the Cybersecurity Awareness Chatbot
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing class objects to handle specific tasks (Modular Design)
            AudioPlayer audio = new AudioPlayer();
            User user = new User();
            Chatbot bot = new Chatbot();

            // STEP 1: Execute multimedia greeting
            audio.PlayWelcomeMessage();

            // STEP 2: Handle User Authentication and data storage
            user.GetUserName();

            bool keepRunning = true;

            // MAIN LOOP: Keeps the application active for multiple queries
            while (keepRunning)
            {
                // Call the logo first so it appears above the menu
                bot.DisplayLogo();

                // Then show the 10 options
                bot.ShowSecurityMenu();

                string input = Console.ReadLine();

                // Logical check for system exit (Choice 0)
                if (input == "0")
                {
                    keepRunning = false;
                    Console.WriteLine($"\n[SYSTEM] Session terminated. Stay safe, {user.Name}.");
                }
                else
                {
                    // STEP 4: Provide specific advice based on user selection
                    bot.GiveAdvice(input);

                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey(); // Wait for user so they can read the advice
                }
            }
        }
    }
} 
//