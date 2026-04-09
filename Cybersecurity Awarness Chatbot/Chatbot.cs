using System;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        // MAIN CONVERSATIONAL LOOP
        public void StartConversation(User user)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                // .Trim() removes accidental spaces that cause "Invalid Selection" errors
                string input = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter something so I can assist you.");
                    continue;
                }

                //  HELP / MENU COMMAND
                if (input.Contains("menu") || input.Contains("options") || input.Contains("help") || input.Contains("show"))
                {
                    Console.WriteLine($"\nCertainly {user.Name}, here is the Cybersecurity Command Center menu:");
                    ShowSecurityMenu();
                }

                //  KEYWORD DETECTION (Priority logic)
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

                //  GREETINGS & PERSONALITY
                else if (input.Contains("hello") || input.Contains("hi"))
                {
                    Console.WriteLine($"Hello {user.Name}! How can I help you today?");
                }
                else if (input.Contains("how are you"))
                {
                    Console.WriteLine($"I'm doing great, {user.Name}! Ready to help you stay safe online.");
                }

                //  NUMBER SUPPORT (Handles "7", "8", "9" etc.)
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

                //  EXIT COMMANDS
                else if (input.Contains("bye") || input.Contains("exit"))
                {
                    Console.WriteLine($"Goodbye {user.Name}! Stay safe.");
                    keepRunning = false;
                }

                // 6. FALLBACK
                else
                {
                    Console.WriteLine("I didn't quite catch that. Type 'menu' to see my topics, or ask about 'passwords'.");
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
                case "1": Console.WriteLine("Advice: Use a unique passphrase of at least 15 characters."); break;
                case "2": Console.WriteLine("Advice: Hover over links to see the real URL before clicking."); break;
                case "3": Console.WriteLine("Advice: Use Authenticator apps instead of SMS for 2FA."); break;
                case "4": Console.WriteLine("Advice: Never log into bank accounts on public Wi-Fi."); break;
                case "5": Console.WriteLine("Advice: Enable 'Auto-Update' to patch vulnerabilities."); break;
                case "6": Console.WriteLine("Advice: Be wary of urgent requests for money or info."); break;
                case "7": Console.WriteLine("Advice: Only download software from official, trusted sources."); break;
                case "8": Console.WriteLine("Advice: Set up remote wipe capabilities for lost devices."); break;
                case "9": Console.WriteLine("Advice: Use the 3-2-1 rule: 3 copies, 2 media, 1 offsite."); break;
                case "10": Console.WriteLine("Advice: Disconnect and change all passwords immediately."); break;
                default: Console.WriteLine("Invalid selection. Please choose a topic between 1 and 10."); break;
            }
            Console.ResetColor();
        }

        // UI ELEMENTS
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

        public void DisplayLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
    =================================================
       ______      __               _____ _     _      _     _ 
      / _____)    | |             / _____) |   (_)    | |   | |
     | /      _   | |__  _____  | (____ | |__  _ _____| | __| |
     | |     | |  |  _ \| ___ |  \____ \|  _ \| | ___ | |/ _  |
     | \_____| |_/| |_) ) ____|  _____) ) | | | | ____| ( (_| |
      \______)___/|____/|_____) (______/|_| |_|_|_____)_|\____|
                                                               
                [ CYBERSECURITY COMMAND CENTER ]
    =================================================
    ");
            Console.ResetColor();
        }
    }
}