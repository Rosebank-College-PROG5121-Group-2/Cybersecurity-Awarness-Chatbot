CyberShield is a C# console-based Intelligent Chatbot designed to educate users on critical cybersecurity practices. Unlike traditional menu systems, CyberShield utilizes Natural Language Processing (NLP) principles to detect keywords in user conversation, providing personalized safety advice in a friendly, interactive environment.

 Key Features
Conversational Logic: Detects keywords like "phishing," "password," and "2FA" within full sentences.

Multimedia Integration: Features a specialized AudioPlayer class that triggers a .wav audio greeting upon launch.

Modular Architecture: Built using clean Object-Oriented Programming (OOP) principles across four dedicated classes.

Defensive Programming: Implements input validation and string sanitization (.Trim(), .ToLower()) to handle user errors gracefully.

Personalized Experience: Captures and stores user data to address the user by name throughout the session.

 Technical Stack
Language: C# (.NET 8.0/10.0)

IDE: Visual Studio 2022

Version Control: Git & GitHub

Multimedia: System.Media (for WAV playback)

 Project Structure (OOP Design)
The project is divided into four main modules to ensure High Cohesion and Low Coupling:

Program.cs: The entry point that coordinates object initialization and program lifecycle.

Chatbot.cs: The "Engine." Contains the conversational loop, keyword detection logic, and the security advice database.

User.cs: Handles user profile data and identity persistence.

AudioPlayer.cs: Manages multimedia assets and error handling for audio playback.