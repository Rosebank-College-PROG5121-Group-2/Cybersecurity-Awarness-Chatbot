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
        // The only field we need — one instance of the Chatbot class
        private Chatbot _chatBot;
    public MainWindow()
        {
            InitializeComponent();

            // Create the chatbot instance
            _chatBot = new Chatbot();

            // Play the voice greeting from Part 1
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

      
        // Reads the user's input, passes it to the Chatbot, and displays
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

            // Get the bot's response
            string response = _chatBot.ProcessInput(userInput);

            // Display the bot's response in the chat
            AppendBotMessage(response);

            // Scroll to the bottom so the latest message is always visible
            ChatScrollViewer.ScrollToBottom();
        }

        //  Message Display Helpers 
        // Adds a user message bubble to the chat display.
        // Styled in a lighter colour and aligned to show it came from the user.
       
        private void AppendUserMessage(string message)
        {
            // Outer border — the message bubble
            Border bubble = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(33, 38, 45)),
                CornerRadius = new CornerRadius(8),
                Padding = new Thickness(12, 8, 12, 8),
                Margin = new Thickness(80, 4, 4, 4),  // Push left so it sits on the right
                HorizontalAlignment = HorizontalAlignment.Right
            };

            // Stack panel holds the label and the message text
            StackPanel stack = new StackPanel();

            // "You" label
            TextBlock label = new TextBlock
            {
                Text = "👤 You",
                Foreground = new SolidColorBrush(Color.FromRgb(139, 148, 158)),
                FontFamily = new FontFamily("Courier New"),
                FontSize = 10,
                Margin = new Thickness(0, 0, 0, 3)
            };

            // The actual message text
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

            // Add the bubble to the chat display
            ChatDisplay.Children.Add(bubble);
        }

        // Adds a bot message bubble to the chat display.
        // Styled in green to match the cybersecurity theme.
       private void AppendBotMessage(string message)
        {
            // Outer border — the message bubble
            Border bubble = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(22, 27, 34)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0, 255, 65)),
                BorderThickness = new Thickness(1, 0, 0, 0),
                CornerRadius = new CornerRadius(8),
                Padding = new Thickness(12, 8, 12, 8),
                Margin = new Thickness(4, 4, 80, 4),  // Push right so it sits on the left
                HorizontalAlignment = HorizontalAlignment.Left
            };

            // Stack panel holds the label and the message text
            StackPanel stack = new StackPanel();

            // "CyberBot" label
            TextBlock label = new TextBlock
            {
                Text = "🤖 CyberBot",
                Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 65)),
                FontFamily = new FontFamily("Courier New"),
                FontSize = 10,
                Margin = new Thickness(0, 0, 0, 3)
            };

            // The actual message text
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

            // Add the bubble to the chat display
            ChatDisplay.Children.Add(bubble);
        }
    }
}
