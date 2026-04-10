using System;
using System.Threading;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        // MAIN CONVERSATIONAL LOOP
        public void StartConversation(User user)
        {
            bool keepRunning = true;

            //  INTRO MESSAGE
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcome {user.Name} to the Cybersecurity Command Center!");
            Thread.Sleep(600);
            Console.WriteLine("You can type 'menu' to see options OR ask me anything about cybersecurity.");
            Thread.Sleep(600);
            Console.WriteLine("Example: 'Tell me about phishing' or 'How do I create a strong password?'");
            Console.ResetColor();

            while (keepRunning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou > ");
                Console.ResetColor();

                string input = Console.ReadLine()?.ToLower().Trim();

                // INPUT VALIDATION
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter something so I can assist you.");
                    continue;
                }

                // HELP / MENU COMMAND
                if (input.Contains("menu") || input.Contains("options") || input.Contains("help") || input.Contains("show"))
                {
                    Console.WriteLine($"\nCertainly {user.Name}, here is the Cybersecurity Command Center menu:");
                    ShowSecurityMenu();
                }

                // KEYWORD DETECTION
                else if (input.Contains("phishing"))
                {
                    GiveAdvice("2");
                }
                else if (input.Contains("password"))
                {
                    GiveAdvice("1");
                }
                else if (input.Contains("2fa") || input.Contains("authentication"))
                {
                    GiveAdvice("3");
                }
                else if (input.Contains("wifi") || input.Contains("wi-fi"))
                {
                    GiveAdvice("4");
                }
                else if (input.Contains("update"))
                {
                    GiveAdvice("5");
                }
                else if (input.Contains("virus") || input.Contains("malware"))
                {
                    GiveAdvice("7");
                }
                else if (input.Contains("backup"))
                {
                    GiveAdvice("9");
                }
                else if (input.Contains("breach") || input.Contains("hacked"))
                {
                    GiveAdvice("10");
                }

                // GREETINGS & PERSONALITY
                else if (input.Contains("hello") || input.Contains("hi"))
                {
                    Console.WriteLine($"Hello {user.Name}! How can I help you today?");
                }
                else if (input.Contains("how are you"))
                {
                    Console.WriteLine($"I'm doing great, {user.Name}! Ready to help you stay safe online.");
                }
                else if (input.Contains("thank"))
                {
                    Console.WriteLine("You're welcome! Stay safe online 😊");
                }

                // NUMBER SUPPORT
                else if (int.TryParse(input, out int choice))
                {
                    if (choice == 0)
                    {
                        Console.WriteLine($"Goodbye {user.Name}! Stay safe.");
                        keepRunning = false;
                    }
                    else
                    {
                        GiveAdvice(input);
                    }
                }

                // EXIT COMMANDS
                else if (input.Contains("bye") || input.Contains("exit") || input.Contains("quit"))
                {
                    Console.WriteLine($"Goodbye {user.Name}! Stay safe.");
                    keepRunning = false;
                }

                // FALLBACK RESPONSE
                else
                {
                    Console.WriteLine("I didn't quite understand that.");
                    Console.WriteLine("Try asking about 'passwords', 'phishing', or type 'menu' to see all topics.");
                }
            }
        }

        // DATABASE OF ADVICE
        public void GiveAdvice(string choice)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[BOT RESPONSE]");

            switch (choice)
            {
                case "1": Console.WriteLine("Use a unique passphrase of at least 15 characters."); break;
                case "2": Console.WriteLine("Hover over links to see the real URL before clicking."); break;
                case "3": Console.WriteLine("Use Authenticator apps instead of SMS for 2FA."); break;
                case "4": Console.WriteLine("Avoid logging into sensitive accounts on public Wi-Fi."); break;
                case "5": Console.WriteLine("Enable auto-updates to patch security vulnerabilities."); break;
                case "6": Console.WriteLine("Be cautious of urgent requests for money or sensitive info."); break;
                case "7": Console.WriteLine("Install antivirus software and avoid suspicious downloads."); break;
                case "8": Console.WriteLine("Enable device tracking and remote wipe for mobile security."); break;
                case "9": Console.WriteLine("Follow the 3-2-1 backup rule: 3 copies, 2 media, 1 offsite."); break;
                case "10": Console.WriteLine("Disconnect immediately and change all your passwords."); break;
                default: Console.WriteLine("Invalid selection. Please choose between 1 and 10."); break;
            }

            Console.ResetColor();
        }

        // UI MENU
        public void ShowSecurityMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- CYBERSECURITY COMMAND CENTER ---");
            Console.WriteLine("1.  Password Security      6.  Social Engineering");
            Console.WriteLine("2.  Phishing Awareness     7.  Malware & Viruses");
            Console.WriteLine("3.  2FA Setup              8.  Mobile Security");
            Console.WriteLine("4.  Public Wi-Fi           9.  Data Backups");
            Console.WriteLine("5.  Software Updates       10. Reporting a Breach");
            Console.WriteLine("0.  Exit System");
            Console.ResetColor();
        }

        // ASCII LOGO
        public void DisplayLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
    ================================================================
      ____        _               ____  _     _      _     _ 
     / ___| _   _| |__   ___ _ __/ ___|| |__ (_) ___| | __| |
    | |   _| | | | '_ \ / _ \ '__\___ \| '_ \| |/ _ \ |/ _` |
    | |__| |_| | | |_) |  __/ |   ___) | | | | |  __/ | (_| |
     \____|\__, |_.__/ \___|_|  |____/|_| |_|_|\___|_|\__,_|
           |___/                                             

        [ C Y B E R  S E C U R I T Y  C O M M A N D  C E N T E R ]
    ================================================================
");
            Console.ResetColor();
        }
    }
}