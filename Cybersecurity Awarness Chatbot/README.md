# CyberShield - Cybersecurity Awareness Command Centre


---

## Project Description
CyberShield is an intelligent, GUI-based interactive application designed to educate users on critical cybersecurity practices. Originally conceived as an NLP-driven console assistant, the project has evolved into a robust WPF desktop command center. By utilizing advanced keyword routing, local data persistence, and real-time activity auditing, CyberShield guides users through security threats in a friendly, high-fidelity terminal environment.

---

## Complete Feature Matrix (Parts 1, 2, and 3)

###  Part 1 & 2 Core Foundations
- **WPF GUI Command Center:** A fully customized dark-mode terminal interface featuring a tailored, stylized ASCII art header and streamlined button controls.
- **Multimedia Integration:** A specialized `AudioPlayer` class leveraging `System.Media` to trigger an automated `.wav` voice greeting protocol upon system initialization.
- **Defensive String Sanitization:** Uses input cleaning tools (`.Trim()`, `.ToLower()`) to gracefully handle variations in user input casing and extra spacing.
- **Personalized Memory & Recall:** Captures and stores user profiling data to address the operator by name throughout the conversational lifecycle.
- **Contextual Sentiment Tracking:** Parses emotional indicators and responds with protective tips when security anxiety or urgency is flagged.

### Part 3 Advanced Integrations
- **Task Assistant with Reminders (CRUD):** A dedicated sub-window interface enabling operators to add, track, resolve, and purge custom mitigation objectives.
- **JSON File Storage Persistence:** Automatically synchronizes database changes to a local `tasks.json` storage file on the host machine, reloading active records seamlessly upon boot.
- **Cybersecurity Mini-Game (Quiz Matrix):** An interactive 11-question evaluation game covering phishing, password safety, browsing, and social engineering. Features single-question rendering, trackable live score states, and immediate defensive explanations after each submission.
- **Activity Log Audit Trail:** Real-time logging of system events (such as task initialization, quiz initialization, and NLP routing matches) with standard system timestamps. Employs a restrictive 5-to-10 entry view filter alongside a "Show More" history expansion.
- **Natural Language Intent Processing:** Advanced phrase matching allowing users to type conversational expressions (e.g., *"what have you done for me?"* or *"test my knowledge"*) to trigger specific diagnostics routines.

---

## Technical Architecture & Stack
- **Language:** C# (.NET 8.0 WPF Framework)
- **Dependency:** `Newtonsoft.Json` framework (Data serialization engine)
- **Version Control:** Git & GitHub Distributed Networks
- **Multimedia Engine:** System.Media Asset Pipeline

---

## Project Structure (OOP Design)
The software workspace enforces High Cohesion and Low Coupling across dedicated modules:
- **`Program.cs` / `MainWindow.xaml.cs`:** Core lifecycle management, window initialization, and main loop routing.
- **`TaskWindow.xaml.cs`:** Separate UI interface controller managing the objective log views.
- **`ChatBot.cs` / `KeywordResponder.cs`:** The core NLP engine managing keyword definitions, phrase extraction, and sentiment responses.
- **`TaskStorageHelper.cs` / `CyberTask.cs`:** Handles local JSON read/write logic and state structures.
- **`QuizManager.cs` / `QuizQuestion.cs`:** Houses the 11-question matrix pool and scoring calculators.
- **`ActivityLogger.cs`:** Captures and formats chronological timestamp events.
- **`User.cs`:** Persists profile identities across stream panels.
- **`AudioPlayer.cs`:** Handles wave asset exception logic for speech playbacks.

---

## Installation & Setup Instructions
1. Clone this repository to your local drive.
2. Launch Visual Studio 2022 and open the solution workspace file `CybersecurityChatbot.sln`.
3. Initialize the package ecosystem dependency by opening the **NuGet Package Manager Console** (`Tools > NuGet Package Manager > Package Manager Console`) and running:
   ```bash
   Install-Package Newtonsoft.Json