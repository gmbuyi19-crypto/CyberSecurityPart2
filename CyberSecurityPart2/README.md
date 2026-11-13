# GemBot – Cybersecurity Awareness Chatbot

GemBot is a Windows Forms (C#) chatbot that helps South African citizens learn how to stay safe online. It was built in three parts for the PROG6221 Portfolio of Evidence:

- **Part 1** – a console chatbot with a voice greeting, ASCII art and basic cybersecurity answers.
- **Part 2** – a graphical user interface (GUI) with keyword recognition, random responses, conversation flow, memory and sentiment detection.
- **Part 3 (POE)** – a Task Assistant with reminders stored in a database, a cybersecurity quiz, NLP simulation and an activity log.

**Student name:** Gemima Tshimanga
**Student number:** ST10499217


---

## Features

### Chat (Parts 1 and 2)
- Voice greeting when the app starts, plus the GemBot logo and ASCII art.
- Asks for the user's name and uses it in replies.
- Recognises cybersecurity keywords such as *password*, *phishing*, *scam*, *privacy*, *browsing* and *social media*.
- Picks random tips from a list so answers are not always the same.
- Follow-up questions such as *"tell me more"* continue the current topic.
- Remembers the user's favourite topic (*"I'm interested in privacy"*) and uses it later.
- Detects feelings such as *worried*, *curious* and *frustrated*, and responds with empathy and a tip.
- Gives a default answer for unknown input and never crashes on unexpected input.
- Typing *exit*, *bye* or *cancel* closes the chatbot.

### Task Assistant with Reminders (Part 3)
- Add tasks with a title, description and optional reminder date on the **Task Assistant** tab.
- View all tasks in a table, mark tasks as completed, or delete them.
- All tasks are stored in a **SQL Server** database, so every change is saved.
- Tasks and reminders can also be added from the chat, for example:
  - `Add task - Review privacy settings` → *"Would you like a reminder?"* → `Yes, remind me in 3 days`
  - `Remind me to update my password tomorrow`
  - `Show my tasks`

### Cybersecurity Quiz (Part 3)
- 12 questions on phishing, passwords, safe browsing and social engineering.
- A mix of multiple-choice and true/false questions, shown one at a time.
- Instant feedback with an explanation after every answer, using varied messages.
- Score shown during the quiz and a final message at the end.
- Can be opened from the chat by typing `start the quiz` or `test me`.

### NLP Simulation (Part 3)
- Recognises different ways of asking for the same thing, e.g. *"add a task"*, *"create a task"*, *"new task"*, *"remind me to…"*.
- Uses `string.Contains()` and regular expressions (Regex) to find keywords, task titles and reminder times such as *"tomorrow"*, *"in 3 days"*, *"in three days"* and *"next week"*.
- Adds a helpful description to tasks based on their keywords (for example *privacy*, *2FA*, *password*).

### Activity Log (Part 3)
- Records important actions with a timestamp: tasks added, completed and deleted, reminders set, quiz started and completed, and advice given.
- The **Activity Log** tab shows the last 5 actions, with a **Show More** button for the full history.
- From the chat, type `show activity log` or `what have you done for me?`, and `show more` for the full list.

---

## Technologies used
- C# and Windows Forms (.NET 8)
- Microsoft SQL Server Express
- Microsoft.Data.SqlClient (NuGet package)
- Visual Studio 2022
- GitHub and GitHub Actions (CI)

---

## How to set up and run

### 1. Requirements
- Windows with Visual Studio 2022 (".NET desktop development" workload)
- SQL Server Express and SQL Server Management Studio (SSMS)

### 2. Get the code
Clone the repository, or download it as a ZIP and extract it:

```
git clone [your repository link]
```

### 3. Create the database
1. Open **SSMS** and connect to `.\SQLEXPRESS` using **Windows Authentication**. Tick **Trust Server Certificate**.
2. Open the file `database/setup.sql` from the project.
3. Click **Execute**. This creates the `cyberbot_db` database and the `tasks` table, with one test task.

### 4. Check the connection string
Open `DATA/DbConfig.cs`. The default connection string is:

```
Server=.\SQLEXPRESS;Database=cyberbot_db;Trusted_Connection=True;TrustServerCertificate=True;
```

If your SQL Server has a different name, change `.\SQLEXPRESS` to your server name (shown in the SSMS Connect window).

### 5. Run the app
1. Open `CyberSecurityPart2.sln` in Visual Studio.
2. Press **F5** (or click **Start**).
3. Type your name in the Chat tab to begin.

---

## Project structure

```
CyberSecurityPart2
├── DATA
│   ├── DbConfig.cs          – database connection string
│   └── TaskRepository.cs    – add, load, complete and delete tasks in SQL Server
├── Models
│   └── TaskItems.cs         – one task (title, description, reminder, completed)
├── SERVICES
│   ├── ActivityLogger.cs    – list of actions with timestamps
│   ├── NlpServices.cs       – recognises commands and task titles
│   ├── QuizService.cs       – quiz questions and feedback
│   └── ReminderParser.cs    – turns "in 3 days" / "tomorrow" into a date
├── database
│   └── setup.sql            – script that creates the database and table
├── Images                   – GemBot logo
├── Voice                    – voice greeting (.wav)
├── ChatEngine.cs            – Part 2 logic: keywords, memory and sentiment
└── Form1.cs                 – the GUI with the Chat, Quiz, Task Assistant and Activity Log tabs
```

---

## Example conversation

```
GemBot: Hello! Welcome to the Cybersecurity Awareness Assistant.
GemBot: Before we start, what is your name?
User:   Thabo
GemBot: Nice to meet you, Thabo! ...
User:   Add task - Review privacy settings
GemBot: Task added with the description "Review account privacy settings to ensure your data is protected." Would you like a reminder?
User:   Yes, remind me in 3 days
GemBot: Got it! I'll remind you about 'Review privacy settings' on [date].
User:   Show activity log
GemBot: Here's a summary of recent actions:
          1. Task added: 'Review privacy settings' (no reminder set)
          2. Reminder set: 'Review privacy settings' on [date]
```

---

## Releases
- **v1.0** – Part 1: console chatbot
- **v2.0** – Part 2: GUI chatbot with keyword recognition, memory and sentiment detection
- **v3.0** – Part 3 (POE): Task Assistant with database, quiz, NLP simulation and activity log

---

## References
Pieterse, H. 2021. The Cyber Threat Landscape in South Africa: A 10-Year Review. *The African Journal of Information and Communication*, 28(28). doi: https://doi.org/10.23962/10539/32213
