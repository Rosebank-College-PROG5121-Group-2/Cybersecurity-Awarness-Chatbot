using System.Collections.Generic;

namespace CybersecurityChatbotGUI
{
    public class QuizManager
    {
        private List<QuizQuestion> questions;
        private int currentQuestionIndex;
        private int score;

        public int CurrentQuestionNumber => currentQuestionIndex + 1;
        public int TotalQuestions => questions.Count;
        public int Score => score;
        public bool IsQuizFinished => currentQuestionIndex >= questions.Count;

        public QuizManager()
        {
            ResetQuiz();
            PopulateQuestions();
        }

        public void ResetQuiz()
        {
            currentQuestionIndex = 0;
            score = 0;
        }

        public QuizQuestion GetCurrentQuestion()
        {
            if (IsQuizFinished) return null;
            return questions[currentQuestionIndex];
        }

        public bool SubmitAnswer(int selectedIndex, out string explanation)
        {
            QuizQuestion current = GetCurrentQuestion();
            explanation = current?.Explanation ?? "";

            bool isCorrect = (selectedIndex == current?.CorrectOptionIndex);
            if (isCorrect) score++;

            currentQuestionIndex++;
            return isCorrect;
        }

        private void PopulateQuestions()
        {
            questions = new List<QuizQuestion>
            {
                new QuizQuestion("An email from 'secure-bank-update@checking-alerts.com' asks you to log in immediately. What should you do?",
                    new List<string> { "Click the link", "Forward it to friends", "Delete it and check your official banking app directly", "Reply to the email" }, 2,
                    "Banks never send urgent security links from suspicious external domains. Always verify via official channels."),

                new QuizQuestion("What is a common sign of a phishing message?",
                    new List<string> { "Urgent language", "Generic greetings like 'Dear Customer'", "Mismatched domain names", "All of the above" }, 3,
                    "Phishing rely heavily on social engineering tactics like high urgency, generic greetings, and deceptive domains."),

                new QuizQuestion("You get a text message claiming you won a lottery prize from a contest you never entered, asking you to click a link. This is called:",
                    new List<string> { "Smishing", "Vishing", "Whaling", "Spear Phishing" }, 0,
                    "Phishing via SMS text messages is formally referred to as Smishing."),

                new QuizQuestion("Which of the following creates the strongest password?",
                    new List<string> { "Your pet's name + '123'", "A unique passphrase of 4 random words and special characters", "Changing 'Password1!' to 'Password2!'", "Reusing your main email password everywhere" }, 1,
                    "Length and randomness are key. Multi-word passphrases are extremely strong against brute-force attacks."),

                new QuizQuestion("What does Multi-Factor Authentication (MFA) provide?",
                    new List<string> { "Faster internet", "An extra layer of defensive verification beyond just a password", "Automatic virus deletion", "Encrypted file compression" }, 1,
                    "MFA requires multiple layers of verification, protecting your account even if your password leaks."),

                new QuizQuestion("How often should you ideally reuse the exact same password across high-profile accounts?",
                    new List<string> { "Every time", "Never", "Only for social media apps", "Only if it has a capital letter" }, 1,
                    "Credential stuffing attacks exploit password reuse across multiple targets."),

                new QuizQuestion("What safety element does the 'S' in HTTPS represent in a website's URL?",
                    new List<string> { "Speed", "System", "Secure (Encryption)", "Scanned" }, 2,
                    "HTTPS establishes a secure, encrypted transit tunnel between your local browser and the remote server."),

                new QuizQuestion("A sudden browser pop-up warns: 'Your PC is infected with 47 viruses! Call this support number.' What is this?",
                    new List<string> { "An official Windows flag", "Scareware/Tech Support Scam", "A legitimate anti-virus scan", "A hardware error" }, 1,
                    "Scareware uses fear tactics to trick users into downloading real malware or calling fraudulent support networks."),

                new QuizQuestion("When downloading executable setup packages from the web, what is the safest standard?",
                    new List<string> { "Clicking bright 'Download Here' ads", "Downloading exclusively from verified vendor home pages", "Using unverified torrent mirrors", "Disabling Windows Defender" }, 1,
                    "Always pull software directly from the trusted manufacturer platform to avoid malicious file-injection vectors."),

                new QuizQuestion("An unknown person tailgating behind you walks into a restricted server room right as you scan your badge. This is called:",
                    new List<string> { "Phishing", "Tailgating / Piggybacking", "Shoulder Surfing", "Dumping" }, 1,
                    "Physical social engineering involving unauthorized persons slipping through doors directly behind authorized personnel is known as tailgating."),

                new QuizQuestion("A technician calls out of nowhere claiming your workstation has errors and demands your remote access code. What should you do?",
                    new List<string> { "Provide the token immediately", "Hang up and verify their identity with your IT helpdesk through official lines", "Give them a fake password", "Leave your workstation running unattended" }, 1,
                    "Vishing (voice phishing) relies on assuming authority figures. Always verify helpdesk claims independently.")
            };
        }
    }
}