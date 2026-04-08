using System;
using System.Media; // Required for SoundPlayer
using System.IO;    // Required for Path handling

namespace CybersecurityChatbot
{
    // Class dedicated to handling audio outputs
    public class AudioPlayer
    {
        public void PlayWelcomeMessage()
        {
            try
            {
                // Combining the base directory with the filename to ensure it works on any PC
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");

                SoundPlayer player = new SoundPlayer(path);
                player.Play(); // Plays the greeting.wav file
            }
            catch (Exception ex)
            {
                // Error Handling (Step 5): Catches issues if the audio driver or file is missing
                Console.WriteLine("Audio could not play: " + ex.Message);
            }
        }
    }
}