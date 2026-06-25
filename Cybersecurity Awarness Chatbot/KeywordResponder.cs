using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
   
    // Handles keyword recognition and random response selection.
   public class KeywordResponder
    {
        // Random object used to pick responses randomly.
        // Declared at class level so it is only created once (best practice).
        private Random _random = new Random();

        private Dictionary<string, List<string>> _responses;

        // Constructor — populates the keyword dictionary when the class is created.
        public KeywordResponder()
        {
            _responses = new Dictionary<string, List<string>>()
            {
                //  PASSWORD 
                {
                    "password",
                    new List<string>
                    {
                        "Use a strong password that is at least 12 characters long and includes uppercase letters, numbers, and symbols. Avoid using your name or birthdate.",
                        "Never reuse the same password across multiple accounts. If one account is hacked, all your accounts become vulnerable.",
                        "Consider using a password manager like Bitwarden or LastPass to generate and store strong, unique passwords securely.",
                        "Enable two-factor authentication (2FA) alongside your password for an extra layer of security on important accounts.",
                        "Change your passwords regularly, especially after a data breach. Check haveibeenpwned.com to see if your email has been compromised."
                    }
                },

                //  PHISHING 
                {
                    "phishing",
                    new List<string>
                    {
                        "Be cautious of emails asking for personal information. Legitimate organisations will never ask for your password via email.",
                        "Check the sender's email address carefully. Phishing emails often use addresses like 'support@paypa1.com' instead of 'support@paypal.com'.",
                        "Hover over links before clicking them. If the URL looks suspicious or doesn't match the claimed website, do not click it.",
                        "If an email creates urgency like 'Your account will be closed in 24 hours', treat it as a red flag — this is a common phishing tactic.",
                        "Report phishing emails to your email provider and delete them immediately. Never download attachments from unknown senders."
                    }
                },

                // PRIVACY
                {
                    "privacy",
                    new List<string>
                    {
                        "Review the privacy settings on your social media accounts regularly. Limit who can see your personal information and posts.",
                        "Be mindful of what you share online. Personal details like your address, ID number, or daily routine can be used against you.",
                        "Use a VPN (Virtual Private Network) when connecting to public Wi-Fi to keep your browsing private and encrypted.",
                        "Read the privacy policy of apps before installing them. Some apps collect and sell your data to third parties.",
                        "Regularly audit which apps have access to your camera, microphone, and location on your phone and revoke unnecessary permissions."
                    }
                },

                // SCAM 
                {
                    "scam",
                    new List<string>
                    {
                        "If an offer sounds too good to be true, it almost certainly is. Be especially cautious of lottery winnings or investment schemes.",
                        "Never send money to someone you have only met online, even if they claim to be in an emergency situation.",
                        "Scammers often impersonate government agencies like SARS or SAPS. Official agencies will never demand immediate payment over the phone.",
                        "Be wary of unsolicited calls asking for your banking details or OTP. Your bank will never ask for your PIN or OTP.",
                        "If you suspect a scam, report it to the South African Fraud Prevention Service (SAFPS) at 0800 222 050."
                    }
                },

                //  MALWARE 
                {
                    "malware",
                    new List<string>
                    {
                        "Install reputable antivirus software and keep it updated. Regular scans can detect and remove malware before it causes damage.",
                        "Never download software from unofficial websites. Always use the official app store or the developer's own website.",
                        "Malware can be hidden in email attachments. Never open attachments from senders you do not recognise.",
                        "Keep your operating system and applications updated. Software updates often include security patches that protect against malware.",
                        "If your device is running slowly, showing unexpected ads, or behaving strangely, it may be infected. Run a full antivirus scan immediately."
                    }
                },

                //  RANSOMWARE 
                {
                    "ransomware",
                    new List<string>
                    {
                        "Back up your important files regularly to an external drive or cloud storage. Ransomware cannot encrypt files it cannot reach.",
                        "Ransomware is often delivered through phishing emails. Never open attachments or links from unknown senders.",
                        "If you are infected with ransomware, do not pay the ransom. There is no guarantee you will get your files back, and it encourages further attacks.",
                        "Disconnect an infected device from the internet and your network immediately to prevent the ransomware from spreading to other devices.",
                        "Report ransomware attacks to the South African Police Service (SAPS) and the Cybersecurity Hub at cybersafety.co.za."
                    }
                },

                // VPN 
                {
                    "vpn",
                    new List<string>
                    {
                        "A VPN encrypts your internet traffic, making it much harder for hackers to intercept your data on public Wi-Fi networks.",
                        "Use a trusted VPN provider. Free VPNs often log your data and may sell it to advertisers — defeating the purpose of privacy.",
                        "A VPN hides your IP address, making your online activity harder to track. This is especially useful when travelling or using hotel Wi-Fi.",
                        "A VPN does not make you completely anonymous online. You still need to practise safe browsing habits alongside using one."
                    }
                },

                //  TWO FACTOR / 2FA 
                {
                    "two factor",
                    new List<string>
                    {
                        "Two-factor authentication (2FA) adds a second verification step when logging in, making it much harder for hackers to access your account even if they have your password.",
                        "Use an authenticator app like Google Authenticator or Microsoft Authenticator instead of SMS-based 2FA where possible — SIM swapping attacks can compromise SMS codes.",
                        "Enable 2FA on your most important accounts first: email, banking, and social media. These are the highest-value targets for attackers.",
                        "Never share your 2FA code with anyone. Legitimate services will never ask for it over the phone or via email."
                    }
                },

                // SOCIAL ENGINEERING 
                {
                    "social engineering",
                    new List<string>
                    {
                        "Social engineering manipulates people into revealing confidential information. Always verify the identity of anyone requesting sensitive data.",
                        "Be suspicious of unsolicited requests for information, even from people claiming to be from IT support or management.",
                        "Attackers may use information from your social media profiles to make their social engineering attempts more convincing. Limit what you share publicly.",
                        "When in doubt, hang up and call the organisation back on their official number to verify the request."
                    }
                },

                // FIREWALL 
                {
                    "firewall",
                    new List<string>
                    {
                        "A firewall monitors and controls incoming and outgoing network traffic. Always keep your device's built-in firewall enabled.",
                        "A firewall is your first line of defence against unauthorised access to your device or network.",
                        "For home networks, ensure your router's firewall is enabled in its settings. This protects all devices connected to your network.",
                        "A firewall alone is not enough — use it alongside antivirus software, strong passwords, and regular updates for full protection."
                    }
                }
            };
        }

        
        // Scans the user's input for any known keyword.
           public string GetResponse(string input)
           {
            // Convert input to lowercase so matching is not case-sensitive
            string lowerInput = input.ToLower();

            // Loop through every keyword in the dictionary
            foreach (var entry in _responses)
            {
                string keyword = entry.Key;
                List<string> responseList = entry.Value;

                // Check if the user's message contains this keyword
                if (lowerInput.Contains(keyword))
                {
                    // Pick a random index from 0 to the end of the list
                    int randomIndex = _random.Next(0, responseList.Count);

                    // Return the randomly selected response
                    return responseList[randomIndex];
                }
            }

            // No keyword matched — return null so ChatBot can use a fallback
            return null;
        }

      // Returns the key (keyword) that was matched in the user's input.
      public string GetMatchedKeyword(string input)
        {
            string lowerInput = input.ToLower();

            foreach (var entry in _responses)
            {
                if (lowerInput.Contains(entry.Key))
                    return entry.Key;
            }

            return null;
        }
    
        // Returns a random response for a specific keyword by name.
      public string GetResponseForTopic(string topic)
        {
            // Check if the topic exists in our dictionary
            if (_responses.ContainsKey(topic))
            {
                List<string> responseList = _responses[topic];
                int randomIndex = _random.Next(0, responseList.Count);
                return responseList[randomIndex];
            }

            // Topic not found return a fallback message
            return "I don't have specific information on that topic yet, but always stay cautious online!";
        }

       // Returns a list of all keywords the bot can recognise.
        public List<string> GetAllKeywords()
        {
            return new List<string>(_responses.Keys);
        }
    }
} 