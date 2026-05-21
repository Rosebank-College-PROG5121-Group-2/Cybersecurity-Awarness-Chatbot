using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    
    // Detects the emotional tone of the user's message and returns
    // an empathetic opening response before the cybersecurity tip is given.
    
    public enum Sentiment
    {
        Neutral,    
        Worried,    
        Curious,    
        Frustrated, 
        Happy       
    }

    public class SentimentDetector
    {
        // A dictionary that maps each Sentiment to a list of words that trigger it.
        // If the user's message contains ANY word from a list, that sentiment is detected.
        private Dictionary<Sentiment, List<string>> _triggerWords;

        // A dictionary that maps each Sentiment to an empathetic response.
        // This is what the bot says BEFORE giving the cybersecurity tip.
        private Dictionary<Sentiment, string> _sentimentResponses;

        // Constructor : runs when SentimentDetector is created.
        // This is where populate both dictionaries.
        public SentimentDetector()
        {
            // Trigger Words
            // Each sentiment has a list of words that indicate the user feels that way.
            _triggerWords = new Dictionary<Sentiment, List<string>>()
            {
                {
                    Sentiment.Worried,
                    new List<string> { "worried", "scared", "afraid", "anxious", "nervous", "unsafe", "frightened", "concerned", "fear", "panic" }
                },
                {
                    Sentiment.Curious,
                    new List<string> { "curious", "wondering", "interested", "want to know", "how does", "what is", "tell me", "explain", "learn", "understand" }
                },
                {
                    Sentiment.Frustrated,
                    new List<string> { "frustrated", "annoyed", "confused", "don't understand", "dont understand", "angry", "irritated", "useless", "difficult", "complicated" }
                },
                {
                    Sentiment.Happy,
                    new List<string> { "great", "thanks", "helpful", "awesome", "love it", "thank you", "amazing", "excellent", "perfect", "brilliant" }
                }
            };

            // Empathetic Responses:
            // These are the sentences the bot uses to acknowledge the user's emotion.
            _sentimentResponses = new Dictionary<Sentiment, string>()
            {
                {
                    Sentiment.Worried,
                    "It's completely understandable to feel that way — cybersecurity threats can be overwhelming. " +
                    "You're already doing the right thing by learning about it. Here's something that will help: "
                },
                {
                    Sentiment.Curious,
                    "I love the curiosity! The more you know, the safer you'll be online. Here's what you should know: "
                },
                {
                    Sentiment.Frustrated,
                    "I hear you — this stuff can feel confusing at first. Let me break it down simply for you: "
                },
                {
                    Sentiment.Happy,
                    "Glad to hear it! Let's keep that positive energy going. Here's another useful tip: "
                },
                {
                    // Neutral means no emotion was detected — return nothing.
                    Sentiment.Neutral,
                    string.Empty
                }
            };
        }
             // Reads the user's input and returns which Sentiment it matches.
            public Sentiment Detect(string input)
         {
            // Convert to lowercase so "Worried" and "worried" both match
            string lowerInput = input.ToLower();

            // Loop through each sentiment and its list of trigger words
            foreach (var entry in _triggerWords)
            {
                Sentiment sentiment = entry.Key;
                List<string> words = entry.Value;

                // Check if the input contains ANY of the trigger words for this sentiment
                foreach (string word in words)
                {
                    if (lowerInput.Contains(word))
                    {
                        // Found a match — return this sentiment immediately
                        return sentiment;
                    }
                }
            }

            // No trigger words found — return Neutral
            return Sentiment.Neutral;
        }
            // Returns the empathetic response string for a given sentiment
            public string GetSentimentResponse(Sentiment sentiment)
        {
            // TryGetValue safely looks up the sentiment in the dictionary
            if (_sentimentResponses.TryGetValue(sentiment, out string response))
                return response;

            // Fallback — should never happen since all sentiments are covered above
            return string.Empty;
        }
    }
}