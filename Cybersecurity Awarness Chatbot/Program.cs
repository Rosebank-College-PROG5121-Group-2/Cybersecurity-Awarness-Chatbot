using System;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing class objects (Modular Design)
            AudioPlayer audio = new AudioPlayer();
            User user = new User();
            Chatbot bot = new Chatbot();

            //  Execute multimedia greeting
            audio.PlayWelcomeMessage();

            //  Handle User Authentication (Capture Name)
            user.GetUserName();

            //  Display the UI Logo
            bot.DisplayLogo();

            //  Hand over control to the Chatbot's conversational loop
            // We pass the 'user' and 'bot' objects so it can use names and advice logic
            Console.WriteLine($"\n[SYSTEM] Connection established. You can now chat with the bot, {user.Name}!");
            bot.StartConversation(user);

            //  Final Exit Message (After the loop inside StartConversation ends)
            Console.WriteLine("\n[SYSTEM] Session terminated. Press any key to close the console...");
            Console.ReadKey();
        }
    }
}