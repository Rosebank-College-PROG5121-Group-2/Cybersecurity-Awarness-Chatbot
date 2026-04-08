using System;

namespace CybersecurityChatbot
{
    // Class containing the security advice database and UI styling
    public class Chatbot
    {
        // Displays the 10-point security menu with color coding
        public void ShowSecurityMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- CYBERSECURITY COMMAND CENTER ---");
            Console.WriteLine("1.  Password Security");
            Console.WriteLine("2.  Phishing Awareness");
            Console.WriteLine("3.  Two-Factor Authentication (2FA)");
            Console.WriteLine("4.  Public Wi-Fi Safety");
            Console.WriteLine("5.  Software Updates");
            Console.WriteLine("6.  Social Engineering");
            Console.WriteLine("7.  Malware & Viruses");
            Console.WriteLine("8.  Mobile Device Security");
            Console.WriteLine("9.  Data Backups");
            Console.WriteLine("10. Reporting a Breach");
            Console.WriteLine("0.  Exit System");
            Console.ResetColor();
            Console.Write("\nSelect a security topic (0-10): ");
        }

        // Uses a Switch Statement to provide advice based on user input
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
                default: Console.WriteLine("Invalid selection. Please choose a valid protocol (0-10)."); break;
            }
            Console.ResetColor();
        }
        public void DisplayLogo()
        {
            Console.Clear(); // Clears previous text so the logo is always at the top
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
