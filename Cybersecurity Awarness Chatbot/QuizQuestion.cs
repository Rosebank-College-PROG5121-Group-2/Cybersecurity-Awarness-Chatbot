using System.Collections.Generic;

namespace CybersecurityChatbotGUI
{
    public class QuizQuestion
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public int CorrectOptionIndex { get; set; }
        public string Explanation { get; set; }

        public QuizQuestion(string text, List<string> options, int correctIndex, string explanation)
        {
            QuestionText = text;
            Options = options;
            CorrectOptionIndex = correctIndex;
            Explanation = explanation;
        }
    }
}