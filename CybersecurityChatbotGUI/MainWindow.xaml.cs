// MainWindow.xaml.cs Connects the WPF GUI to the Chatbot logic
using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CybersecurityChatbot;

namespace CybersecurityChatbotGUI
{
    public partial class MainWindow : Window
    {
        private Chatbot _chatBot;

        // Quiz state manager variables
        private QuizManager quizManager = new QuizManager();
        private bool isQuizActive = false;

        public MainWindow()
        {
            InitializeComponent();

            // Create the chatbot instance
            _chatBot = new Chatbot();

            // Play the voice greeting 
            PlayVoiceGreeting();

            // Show the opening message from the bot
            AppendBotMessage(_chatBot.GetGreeting());
        }

        //  Voice Greeting
        private void PlayVoiceGreeting()
        {
            try
            {
                // Look for greeting.wav in the output directory
                string wavPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");

                if (System.IO.File.Exists(wavPath))
                {
                    SoundPlayer player = new SoundPlayer(wavPath);
                    player.Play();
                }
            }
            catch (Exception)
            {
                // Silently continue if audio fails — app still works
            }
        }

        //  UI Event Handlers 
        // Called when the Send button is clicked.
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        // Called when the user presses a key in the input box.
        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SendMessage();
        }

        //  Core Send Logic 
        // Reads the user's input, passes it to the Chatbot or Quiz, and displays
        private void SendMessage()
        {
            // Read what the user typed
            string userInput = UserInput.Text.Trim();

            // Don't send empty messages
            if (string.IsNullOrWhiteSpace(userInput))
                return;

            // Display the user's message in the chat
            AppendUserMessage(userInput);

            // Clear the input box ready for next message
            UserInput.Clear();

            string cleanInput = userInput.ToLower().Trim();

            // 1. STATE CHECK: Is the Quiz NOT currently running?
            if (!isQuizActive)
            {
                // Check if the user is attempting to start the quiz using NLP intents
                if (cleanInput.Contains("start quiz") || cleanInput.Contains("play game") || cleanInput.Contains("test my knowledge"))
                {
                    isQuizActive = true;
                    quizManager.ResetQuiz();

                    string initialMessage = "🎮 Cybersecurity Quiz Started!\n" +
                                           "Answer by typing the number of your option (1, 2, 3, or 4).\n\n" +
                                           FormatQuestionOutput();

                    AppendBotMessage(initialMessage);
                }
                else
                {
                    // Fall back to regular chatbot processing from Part 2
                    string response = _chatBot.ProcessInput(userInput);
                    AppendBotMessage(response);
                }
            }
            // 2. STATE CHECK: The user is currently participating in the active quiz
            else
            {
                if (int.TryParse(userInput, out int choice) && choice >= 1 && choice <= 4)
                {
                    // Convert 1-based user menu input to 0-based array index
                    bool isCorrect = quizManager.SubmitAnswer(choice - 1, out string explanation);

                    string feedback = isCorrect ? "✅ Correct!\n" : "❌ Incorrect.\n";
                    feedback += $"💡 Explanation: {explanation}\n\n";

                    if (!quizManager.IsQuizFinished)
                    {
                        feedback += FormatQuestionOutput();
                        AppendBotMessage(feedback);
                    }
                    else
                    {
                        // Quiz completion block
                        feedback += $"🏁 Quiz Finished! Your final score is {quizManager.Score}/{quizManager.TotalQuestions}.\n\n";

                        if (quizManager.Score >= 8)
                            feedback += "🛡️ Fantastic job! You have excellent cybersecurity practices.";
                        else
                            feedback += "⚠️ Good effort, but consider reviewing core safety habits.";

                        AppendBotMessage(feedback);
                        isQuizActive = false; // Gracefully return to chatbot mode
                    }
                }
                else
                {
                    AppendBotMessage("⚠️ Invalid input. Please enter a valid number between 1 and 4 to pick an option.");
                }
            }

            // Scroll to the bottom so the latest message is always visible
            ChatScrollViewer.ScrollToBottom();
        }

        // Helper method to format the current active question beautifully for the UI
        private string FormatQuestionOutput()
        {
            var q = quizManager.GetCurrentQuestion();
            if (q == null) return "";

            string output = $"Question {quizManager.CurrentQuestionNumber} of {quizManager.TotalQuestions}:\n" +
                            $"{q.QuestionText}\n\n";

            for (int i = 0; i < q.Options.Count; i++)
            {
                output += $"{i + 1}. {q.Options[i]}\n";
            }

            return output;
        }

        //  Message Display Helpers 
        // Adds a user message bubble to the chat display.
        private void AppendUserMessage(string message)
        {
            Border bubble = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(33, 38, 45)),
                CornerRadius = new CornerRadius(8),
                Padding = new Thickness(12, 8, 12, 8),
                Margin = new Thickness(80, 4, 4, 4),
                HorizontalAlignment = HorizontalAlignment.Right
            };

            StackPanel stack = new StackPanel();

            TextBlock label = new TextBlock
            {
                Text = "👤 You",
                Foreground = new SolidColorBrush(Color.FromRgb(139, 148, 158)),
                FontFamily = new FontFamily("Courier New"),
                FontSize = 10,
                Margin = new Thickness(0, 0, 0, 3)
            };

            TextBlock text = new TextBlock
            {
                Text = message,
                Foreground = new SolidColorBrush(Color.FromRgb(201, 209, 217)),
                FontFamily = new FontFamily("Courier New"),
                FontSize = 13,
                TextWrapping = TextWrapping.Wrap
            };

            stack.Children.Add(label);
            stack.Children.Add(text);
            bubble.Child = stack;

            ChatDisplay.Children.Add(bubble);
        }

        // Adds a bot message bubble to the chat display.
        private void AppendBotMessage(string message)
        {
            Border bubble = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(22, 27, 34)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0, 255, 65)),
                BorderThickness = new Thickness(1, 0, 0, 0),
                CornerRadius = new CornerRadius(8),
                Padding = new Thickness(12, 8, 12, 8),
                Margin = new Thickness(4, 4, 80, 4),
                HorizontalAlignment = HorizontalAlignment.Left
            };

            StackPanel stack = new StackPanel();

            TextBlock label = new TextBlock
            {
                Text = "🤖 CyberBot",
                Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 65)),
                FontFamily = new FontFamily("Courier New"),
                FontSize = 10,
                Margin = new Thickness(0, 0, 0, 3)
            };

            TextBlock text = new TextBlock
            {
                Text = message,
                Foreground = new SolidColorBrush(Color.FromRgb(201, 209, 217)),
                FontFamily = new FontFamily("Courier New"),
                FontSize = 13,
                TextWrapping = TextWrapping.Wrap
            };

            stack.Children.Add(label);
            stack.Children.Add(text);
            bubble.Child = stack;

            ChatDisplay.Children.Add(bubble);
        }

        private void btnTasks_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.Show();
        }
    }
}