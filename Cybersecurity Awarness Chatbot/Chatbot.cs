using System;
using System.Collections.Generic;
using System.Threading;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        
        public void StartConversation(User user)
        {
            bool keepRunning = true;

        
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
                    Console.WriteLine("You're welcome! Stay safe online :) ");
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
                                                                                                                             
       ______          __                       ______   __        _         __        __   
 .' ___  |        [  |                    .' ____ \ [  |      (_)       [  |      |  ]  
/ .'   \_|  _   __ | |.--.   .---.  _ .--.| (___ \_| | |--.   __  .---.  | |  .--.| |   
| |        [ \ [  ]| '/'`\ \/ /__\\[ `/'`\]_.____`.  | .-. | [  |/ /__\\ | |/ /'`\' |   
\ `.___.'\  \ '/ / |  \__/ || \__., | |   | \____) | | | | |  | || \__., | || \__/  |   
 `.____ .'[\_:  / [__;.__.'  '.__.'[___]   \______.'[___]|__][___]'.__.'[___]'.__.;__]  
           \__.'                                                                        
                                                                                                                        

        | C Y B E R  S E C U R I T Y  C O M M A N D  C E N T E R |
    ================================================================
");
            Console.ResetColor();
        }

     
        private KeywordResponder _keywords = new KeywordResponder();
        private SentimentDetector _sentiment = new SentimentDetector();
        private MemoryStore _memory = new MemoryStore();
        private Random _random = new Random();

        // Tracks whether we are still waiting for the user's name on first launch
        private bool _awaitingName = true;

        // Remembers the last matched keyword so "tell me more" can continue the topic
        private string _lastTopic = string.Empty;

   
        // Returns the opening message shown in the GUI when the app launches.
        // Called once by MainWindow in its constructor.

        public string GetGreeting()
        {
            return "Hello! I'm CyberBot, your Cybersecurity Awareness Assistant.\n" +
                   "I'm here to help you stay safe online.\n\n" +
                   "Before we start — what's your name?";
        }

      
        /// The main method called by the GUI every time the user sends a message
      public string ProcessInput(string userInput)
        {
           
            if (string.IsNullOrWhiteSpace(userInput))
                return "Please type a message before sending.";

            string input = userInput.Trim();
            string lowerInput = input.ToLower();

            //   Waiting for name 
            if (_awaitingName)
            {
                _memory.UserName = CapitaliseName(input);
                _awaitingName = false;

                return $"Great to meet you, {_memory.UserName}! :)\n\n" +
                       $"I can help you with passwords, phishing, privacy, scams, malware and more.\n\n" +
                       $"What would you like to know about today?";
            }

            //  Special commands 
            if (lowerInput.Contains("what can you do") || lowerInput.Contains("help") ||
                lowerInput.Contains("menu") || lowerInput.Contains("topics"))
            {
                return GetTopicsList();
            }

            if (lowerInput.Contains("how are you"))
                return $"I'm doing great{GetNameSuffix()}! Ready to help you stay safe online.";

            if (lowerInput.Contains("purpose") || lowerInput.Contains("what are you"))
                return "My purpose is to help you stay safe online by providing cybersecurity tips and guidance.";

            //  Follow-up phrases 
            if (IsFollowUp(lowerInput))
            {
                if (!string.IsNullOrEmpty(_lastTopic))
                    return $"Sure{GetNameSuffix()}, here's more on {_lastTopic}:\n\n" +
                           _keywords.GetResponseForTopic(_lastTopic);
                else
                    return "I'm not sure what topic to continue. Could you ask me about something specific first?";
            }

            //  User sharing their interest 
            if (lowerInput.Contains("interested in") || lowerInput.Contains("i like"))
            {
                string matchedKeyword = _keywords.GetMatchedKeyword(input);
                if (matchedKeyword != null)
                {
                    _memory.FavouriteTopic = matchedKeyword;
                    return $"Great{GetNameSuffix()}! I'll remember that you're interested in {matchedKeyword}.\n\n" +
                           _keywords.GetResponseForTopic(matchedKeyword);
                }
            }

            //  Sentiment detection 
            Sentiment detectedSentiment = _sentiment.Detect(input);
            string sentimentOpener = _sentiment.GetSentimentResponse(detectedSentiment);

            //  Keyword recognition
            string keywordResponse = _keywords.GetResponse(input);
            if (keywordResponse != null)
            {
                _lastTopic = _keywords.GetMatchedKeyword(input);

                string personalisedOpener = _memory.GetPersonalisedOpener();
                string fullResponse = string.Empty;

                if (!string.IsNullOrEmpty(sentimentOpener))
                    fullResponse += sentimentOpener + "\n\n";

                if (!string.IsNullOrEmpty(personalisedOpener))
                    fullResponse += personalisedOpener + "\n\n";

                fullResponse += keywordResponse;
                fullResponse += $"\n\nSay 'tell me more' for another tip on {_lastTopic}.";

                return fullResponse;
            }

            // Sentiment but no keyword 
            // User expressed emotion but didn't mention a specific topic
            if (detectedSentiment != Sentiment.Neutral)
            {
                return sentimentOpener +
                       $"\n\nI want to help{GetNameSuffix()}. What cybersecurity topic are you concerned about?";
            }

            // Fallback 
            return $"I didn't quite understand that{GetNameSuffix()}. " +
                   $"Try asking about passwords, phishing, or type 'help' to see all topics.";
        }

        // Private Helper Methods 

       
        /// Returns true if the input is a follow-up phrase like "tell me more".
       
        private bool IsFollowUp(string lowerInput)
        {
            string[] phrases = { "tell me more", "explain more", "more info",
                                  "another tip",  "more details",  "continue", "go on" };
            foreach (string phrase in phrases)
                if (lowerInput.Contains(phrase)) return true;
            return false;
        }

        
        //Returns Name if we know the user's name, otherwise empty string.
        // Used to personalise responses naturally mid-sentence.
        
        private string GetNameSuffix()
        {
            return _memory.HasName() ? $", {_memory.UserName}" : string.Empty;
        }

        
        // Capitalises the first letter of each word in the user's name.
         private string CapitaliseName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return name;
            string[] words = name.Trim().Split(' ');
            for (int i = 0; i < words.Length; i++)
                if (words[i].Length > 0)
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            return string.Join(" ", words);
        }

       
        // Builds a response listing all topics the bot can help with.
        private string GetTopicsList()
        {
            return $"Here's what I can help you with{GetNameSuffix()}:\n\n" +
                   " Topics: passwords, phishing, privacy, scams, malware, " +
                   "ransomware, vpn, firewall, two factor, social engineering\n\n" +
                   "• Say 'tell me more' for another tip on the current topic\n" +
                   "• Tell me what you're interested in and I'll remember it\n" +
                   "• Ask 'how are you' or 'what is your purpose'";
        }
    }
}