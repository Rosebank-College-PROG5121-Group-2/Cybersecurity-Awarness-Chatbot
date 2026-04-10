#  CyberShield – Intelligent Security Chatbot

**CyberShield** is a C# console-based chatbot designed to educate users on critical cybersecurity practices through an interactive, conversational interface. 

Unlike traditional index-based menu systems, CyberShield utilizes **Natural Language Processing (NLP) principles** to detect keywords within user input, providing a more intuitive and personalized user experience.

 Key Features

* Conversational Intelligence:** Uses keyword detection logic to identify topics like *phishing*, *passwords*, and *2FA* within natural sentences.
* Multimedia Integration:** Features a dedicated `AudioPlayer` class that triggers a `.wav` audio greeting upon launch using the `System.Media` namespace.
* Modular OOP Architecture:** Built with a focus on **High Cohesion and Low Coupling**, separating concerns across four dedicated classes.
* Defensive Programming:** Implements robust input validation and string sanitization (`.Trim()`, `.ToLower()`) to handle user errors gracefully.
  CI/CD Pipeline:** Integrated with **GitHub Actions** to ensure continuous integration and successful build verification on every push.

Technical Stack

 **Language:** C# (.NET 8.0)
 **Environment:** Console Application
 **Version Control:** Git & GitHub
 **Multimedia:** System.Media (WAV Playback)
 **Automation:** GitHub Actions (CI)

 Project Structure (OOP Design)

The application follows a modular design to ensure scalability and readability:

 Class | Responsibility |
 :--- | :--- |
 **Program.cs** | The entry point; coordinates initialization and the program lifecycle. |
 **Chatbot.cs** | The "Engine"; contains the main loop, keyword logic, and security database. |
 **User.cs** | Handles user profile data and session identity persistence. |
 **AudioPlayer.cs** | Manages multimedia assets and provides error handling for audio playback. |

##  Installation & Usage

1.  **Clone the Repo:** ```bash
    git clone [https://github.com/Rosebank-College-PROG5121-Group-2/Cybersecurity-Awarness-Chatbot.git](https://github.com/Rosebank-College-PROG5121-Group-2/Cybersecurity-Awarness-Chatbot.git)
    ```
2.  **Restore & Build:** Open the `.sln` file in Visual Studio and build the solution.
3.  **Run:** Ensure `greeting.wav` is in the output directory to hear the audio greeting!
##  CI/CD Status
This project utilizes GitHub Actions to maintain code quality. 
Check the **Actions** tab for the latest build status.
