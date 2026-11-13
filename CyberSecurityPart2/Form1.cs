using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CyberSecurityPart2.DATA;
using CyberSecurityPart2.Models;
using CyberSecurityPart2.SERVICES;

namespace CyberSecurityPart2
{
    public partial class Form1 : Form
    {

        private string userName = "";
        private string lastTopic = "";
        private string favouriteTopic = "";
        private Random rng = new Random();

        ChatEngine key = new ChatEngine();
        TaskRepository taskRepo = new TaskRepository();   // does all the database work for task
        ActivityLogger log = new ActivityLogger();       // records everything the bot does
        int waitingForReminderTaskId = -1;                // a task waiting for "yes, remind me in..." (-1 = none)
        string waitingForReminderTitle = "";
        public Form1()
        {
            InitializeComponent();
            ChatInput_TextChanged(this, EventArgs.Empty);

            PlaySound();
            LoadImage();

            //POPULATING THE KEYWORD RESPONSES FOR THE CHATBOT

            key.keywordResponses["Password"] = new List<string> { "Use strong passwords with at least 12 characters, including uppercase, lowercase, numbers, and symbols. Never reuse passwords!" };
            key.keywordResponses["Phishing"] = new List<string> { "Never click on suspicious links or download attachments from unknown senders. Always check the sender's email address carefully!" };
            key.keywordResponses["Browsing, Browser, website"] = new List<string> { "Look for 'https://' in URLs, use ad-blockers, and keep your browser updated to the latest version!" };
            key.keywordResponses["Social media, Facebook, Privacy"] = new List<string> { "Limit what personal information you share, use strict privacy settings, and be careful about what you post online!" };
            key.keywordResponses["Security, Cyber, Protect"] = new List<string> { "Keep your software updated, use antivirus protection, backup your data regularly, and always be cautious online!" };
            key.keywordResponses["how are you, how's it going"] = new List<string> { "I'm doing great, thank you! How can I help you stay safe online?" };
            key.keywordResponses["purpose, what do you do"] = new List<string> { "My purpose is to educate people about cybersecurity and help them stay safe online!" };
            key.keywordResponses["what can i ask,questions"] = new List<string> { "You can ask me about passwords, phishing, safe browsing, social media safety, and general cybersecurity tips!" };

            key.keywordResponses["Scam, Fraud, OTP"] = new List<string>{"If an offer sounds too good to be true, like a prize for a competition you never entered, it is probably a scam.",
                                 "Never share a one-time PIN (OTP) with anyone - not even someone who says they are from your bank.",
                                 "Be careful of job offers that ask you to pay a fee upfront. Real employers don't charge you to work.",
                                 "If you think you've been scammed, contact your bank immediately and report it to the police."
};
            // EXTRA TIPS 

            // Password
            key.keywordResponses["Password"].Add("Never reuse the same password on different accounts. If one site is hacked, criminals try it everywhere else.");
            key.keywordResponses["Password"].Add("Avoid using your name, birthday or ID number in a password - they are easy to guess.");
            key.keywordResponses["Password"].Add("Turn on two-factor authentication (2FA) so a stolen password alone can't get into your account.");

            // Phishing
            key.keywordResponses["Phishing"].Add("Be cautious of emails asking for personal information. Scammers often pretend to be trusted organisations like banks.");
            key.keywordResponses["Phishing"].Add("Check the sender's email address carefully - a fake one can look almost exactly like the real one.");
            key.keywordResponses["Phishing"].Add("Your bank will never ask for your PIN, password or OTP by email, SMS or phone call.");

            // Privacy and social media
            key.keywordResponses["Social media, Facebook, Privacy"].Add("Check which permissions your apps have. A torch app doesn't need your contacts or location!");
            key.keywordResponses["Social media, Facebook, Privacy"].Add("Don't post that you're on holiday while you're away - it tells criminals your home may be empty.");
            key.keywordResponses["Social media, Facebook, Privacy"].Add("Be careful of friend requests from people you don't know. Fake profiles are often used in scams.");

            // GREETINGS - so the bot replies when the user says hi
            key.keywordResponses["Hi, Hy, Hey, Hello, Howzit, Good morning, Good afternoon, Good evening, Greetings"] = new List<string>
{  "Hello! It's great to chat with you. What would you like to learn about staying safe online?",
            "Hi there! Ask me about passwords, phishing, scams, privacy or safe browsing.",
            "Hey! I'm here to help you stay safe online. What's on your mind?"
};
            // Safe browsing
            key.keywordResponses["Browsing, Browser, website"].Add("Keep your web browser updated so it has the latest security fixes.");
            key.keywordResponses["Browsing, Browser, website"].Add("Be careful on public Wi-Fi. Avoid logging into banking apps on open networks.");
        }

        private void PlaySound()
        {
            string soundPath = Path.Combine(Application.StartupPath, "Voice", "C:\\Users\\Student\\source\\repos\\CyberSecurityPart2\\CyberSecurityPart2\\Voice\\chatbot_recording.wav");

            if (File.Exists(soundPath))
            {
                SoundPlayer player = new SoundPlayer(soundPath);
                player.Play();
            }
            else
            {
                MessageBox.Show("Sound file not found.");
            }
        }

        private void LoadImage()
        {
            string imagePath = Path.Combine(Application.StartupPath, "images", "C:\\Users\\Student\\source\\repos\\CyberSecurityPart2\\CyberSecurityPart2\\Images\\chatbot_logo.png");

            Size targetSize = pictureBox1.ClientSize;
            if (targetSize.Width <= 0 || targetSize.Height <= 0)
            {
                targetSize = new Size(200, 200);
            }

            if (!File.Exists(imagePath))
            {
                MessageBox.Show("Image file not found.");
                return;
            }


            using (Image original = Image.FromFile(imagePath))
            {
                float ratio = Math.Min(targetSize.Width / (float)original.Width, targetSize.Height / (float)original.Height);
                int destWidth = Math.Max(1, (int)(original.Width * ratio));
                int destHeight = Math.Max(1, (int)(original.Height * ratio));

                using (Bitmap bmp = new Bitmap(destWidth, destHeight))
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(original, 0, 0, destWidth, destHeight);

                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = new Bitmap(bmp);
                }
            }

            // Keep the image centered in the PictureBox.
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        // SEND BUTTON: takes what the user typed and shows the bot's reply
        // SEND BUTTON: runs the same send code as pressing Enter
        private void button2_Click(object sender, EventArgs e)
        {
            ChatInput_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            // ---------- COLOURS (dark purple theme to match the GemBot logo) ----------
            Color background = Color.FromArgb(24, 20, 45);
            Color chatBoxColour = Color.FromArgb(38, 33, 68);
            Color accent = Color.FromArgb(214, 130, 220);

            this.BackColor = background;
            this.ForeColor = accent;        // labels (like the ASCII art)
            this.AcceptButton = button2;    // pressing Enter clicks Send

            // Big chat box: only for showing messages
            ChatInput.ReadOnly = true;
            ChatInput.BackColor = chatBoxColour;
            ChatInput.ForeColor = Color.White;
            ChatInput.Font = new Font("Segoe UI", 10);
            ChatInput.BorderStyle = BorderStyle.None;

            // Typing box: same width as the chat box, leaving room for the button
            ChatInput2.Font = new Font("Segoe UI", 11);
            ChatInput2.Left = ChatInput.Left;
            ChatInput2.Top = ChatInput.Bottom + 15;
            ChatInput2.Width = ChatInput.Width - 110;

            // Send button: right next to the typing box
            button2.Text = "Send";
            button2.BackColor = Color.FromArgb(150, 80, 190);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button2.Width = 100;
            button2.Height = ChatInput2.Height;
            button2.Left = ChatInput2.Right + 10;
            button2.Top = ChatInput2.Top;

            // ---------- ASCII ART from Part 1 ----------
            Label asciiLabel = new Label();
            asciiLabel.Text =
        @"  ____                 ____        _
 / ___| ___ _ __ ___  | __ )  ___ | |_
| |  _ / _ \ '_ ` _ \ |  _ \ / _ \| __|
| |_| |  __/ | | | | || |_) | (_) | |_
 \____|\___|_| |_| |_||____/ \___/ \__|";
            asciiLabel.Font = new Font("Consolas", 9);   // same-width letters so the art lines up
            asciiLabel.AutoSize = true;
            asciiLabel.Location = new Point(ChatInput.Left, 20);
            tabChat.Controls.Add(asciiLabel);

            // ---------- WELCOME MESSAGE ----------
            ChatInput.AppendText("GemBot: Hello! Welcome to the Cybersecurity Awareness Assistant." + Environment.NewLine + Environment.NewLine);
            ChatInput.AppendText("GemBot: Before we start, what is your name?" + Environment.NewLine + Environment.NewLine);

            // Cursor in the typing box, and set the Send button's starting state
            ChatInput2.Focus();
            ChatInput2_TextChanged(this, EventArgs.Empty);
        }


        // Sends the user's message and shows GemBot's reply.
        // Runs when Enter is pressed, and also when the Send button is clicked.
        private void ChatInput_KeyDown(object sender, KeyEventArgs e)
        {
            // Only react to the Enter key
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            e.SuppressKeyPress = true;   // stops the Windows "ding" sound

            // Two new lines, used to leave a gap between messages
            string gap = Environment.NewLine + Environment.NewLine;

            string input = ChatInput2.Text.Trim();   // get what the user typed
            ChatInput2.Clear();                      // empty the typing box
            ChatInput2.Focus();                      // cursor back in the typing box

            // Input validation: don't allow empty messages
            if (input == "")
            {
                ChatInput.AppendText("GemBot: Please type a message first." + gap);
                return;
            }

            // EXIT: if the user wants to leave, say goodbye and close the program
            string lower = input.ToLower();
            if (lower == "exit" || lower == "quit" || lower == "bye" || lower == "goodbye" || lower == "cancel")
            {
                        // Show what the user typed
        ChatInput.AppendText(key.GetUserName() + ": " + input + gap);

                // ---------- 1. Answer to "Would you like a reminder?" ----------
                // If the user asks for a NEW task or reminder, stop waiting for the old one
                bool isNewRequest = NlpServices.IsAddTask(input) ||
                                    (NlpServices.IsReminder(input) && NlpServices.GetTaskTitle(input) != "");
                if (isNewRequest)
                {
                    waitingForReminderTaskId = -1;
                }

                if (waitingForReminderTaskId != -1)
                {
            int taskId = waitingForReminderTaskId;
            string taskTitle = waitingForReminderTitle;
            waitingForReminderTaskId = -1;   // stop waiting

            DateTime? answerDate = ReminderParser.GetReminderDate(input);

            if (NlpServices.IsYes(input) || answerDate != null)
            {
                // User said yes but no time, so ask when
                if (answerDate == null)
                {
                    ChatInput.AppendText("GemBot: When should I remind you? You can say \"in 3 days\" or \"tomorrow\"." + gap);
                    waitingForReminderTaskId = taskId;   // keep waiting
                    return;
                }

                taskRepo.SetReminder(taskId, answerDate.Value);
                ChatInput.AppendText("GemBot: Got it! I'll remind you about '" + taskTitle + "' on " + answerDate.Value.ToString("dd MMM yyyy") + "." + gap);
                log.Add("Reminder set: '" + taskTitle + "' on " + answerDate.Value.ToString("dd MMM yyyy"));
                return;
            }

            if (input.ToLower().StartsWith("no"))
            {
                ChatInput.AppendText("GemBot: No problem, I won't set a reminder for '" + taskTitle + "'." + gap);
                return;
            }
        }

        // ---------- 2. Reminders, e.g. "Remind me to update my password tomorrow" ----------
        if (NlpServices.IsReminder(input))
        {
            string title = NlpServices.GetTaskTitle(input);
            if (title == "")
            {
                ChatInput.AppendText("GemBot: What should I remind you about? For example: \"Remind me to update my password tomorrow\"." + gap);
                return;
            }

            DateTime? date = ReminderParser.GetReminderDate(input);
            int newId = taskRepo.AddTask(title, NlpServices.GetDescription(title), date);

            if (date != null)
            {
                ChatInput.AppendText("GemBot: Reminder set for '" + title + "' on " + date.Value.ToString("dd MMM yyyy") + "." + gap);
                log.Add("Reminder set: '" + title + "' on " + date.Value.ToString("dd MMM yyyy"));
            }
            else
            {
                ChatInput.AppendText("GemBot: I've added '" + title + "'. When should I remind you? (e.g. \"in 3 days\")" + gap);
                log.Add("Task added: '" + title + "' (no reminder set yet)");
                waitingForReminderTaskId = newId;
                waitingForReminderTitle = title;
            }
            return;
        }

        // ---------- 3. Adding a task, e.g. "Add task - Review privacy settings" ----------
        if (NlpServices.IsAddTask(input))
        {
            string title = NlpServices.GetTaskTitle(input);
            if (title == "")
            {
                ChatInput.AppendText("GemBot: What is the task? For example: \"Add task - Review privacy settings\"." + gap);
                return;
            }

            string description = NlpServices.GetDescription(title);
            DateTime? date = ReminderParser.GetReminderDate(input);
            int newId = taskRepo.AddTask(title, description, date);

            if (date != null)
            {
                ChatInput.AppendText("GemBot: Task added: '" + title + "' with a reminder on " + date.Value.ToString("dd MMM yyyy") + "." + gap);
                log.Add("Task added: '" + title + "' (reminder on " + date.Value.ToString("dd MMM yyyy") + ")");
            }
            else
            {
                ChatInput.AppendText("GemBot: Task added with the description \"" + description + "\" Would you like a reminder?" + gap);
                log.Add("Task added: '" + title + "' (no reminder set)");
                waitingForReminderTaskId = newId;
                waitingForReminderTitle = title;
            }
            return;
        }

        // ---------- 4. Show tasks ----------
        if (NlpServices.IsShowTasks(input))
        {
            List<TaskItems> tasks = taskRepo.GetAllTasks();
            if (tasks.Count == 0)
            {
                ChatInput.AppendText("GemBot: You don't have any tasks yet. Try \"Add task - Enable 2FA\"." + gap);
                return;
            }

            string list = "GemBot: Here are your tasks:" + Environment.NewLine;
            int number = 1;
            foreach (TaskItems task in tasks)
            {
                string status = task.IsCompleted ? "done" : "not done";
                string reminder = task.ReminderDate == null ? "no reminder" : "reminder " + task.ReminderDate.Value.ToString("dd MMM yyyy");
                list += "  " + number + ". " + task.Title + " (" + status + ", " + reminder + ")" + Environment.NewLine;
                number++;
            }
            ChatInput.AppendText(list + Environment.NewLine);
            return;
        }

        // ---------- 5. Quiz ----------
        if (NlpServices.IsQuiz(input))
        {
            ChatInput.AppendText("GemBot: Let's test your cybersecurity knowledge! Opening the Quiz tab for you..." + gap);
            log.Add("Quiz opened from the chat");
            tabControl2.SelectedTab = tabQuiz;
            return;
        }

        // ---------- 6. Full activity log ("show more") ----------
        if (NlpServices.IsShowMore(input))
        {
            List<string> all = log.GetAll();
            if (all.Count == 0)
            {
                ChatInput.AppendText("GemBot: I haven't done anything yet." + gap);
                return;
            }

            string text = "GemBot: Here is the full history:" + Environment.NewLine;
            for (int i = 0; i < all.Count; i++)
            {
                text += "  " + (i + 1) + ". " + all[i] + Environment.NewLine;
            }
            ChatInput.AppendText(text + Environment.NewLine);
            return;
        }

        // ---------- 7. Recent activity log (last 5 actions) ----------
        if (NlpServices.IsShowLog(input))
        {
            List<string> recent = log.GetRecent(5);
            if (recent.Count == 0)
            {
                ChatInput.AppendText("GemBot: I haven't done anything yet." + gap);
                return;
            }

            string text = "GemBot: Here's a summary of recent actions:" + Environment.NewLine;
            for (int i = 0; i < recent.Count; i++)
            {
                text += "  " + (i + 1) + ". " + recent[i] + Environment.NewLine;
            }
            if (log.GetAll().Count > recent.Count)
            {
                text += "  Type \"show more\" to see the full history." + Environment.NewLine;
            }
            ChatInput.AppendText(text + Environment.NewLine);
            return;
        }

        // ---------- 8. Everything else ----------
        string reply = key.GetResponse(input);
        ChatInput.AppendText("GemBot: " + reply + gap);

        // Log the advice it gave (but not when it didn't understand)
        if (!reply.StartsWith("I'm not sure"))
        {
            log.Add("Gave cybersecurity advice for: '" + input + "'");
        }

                MessageBox.Show("Goodbye! Stay safe online.", "GemBot");   // gives the user time to read it
                this.Close();                                             // closes the chatbot window
                return;
            }

            // try/catch so the chatbot never crashes on unexpected input
            try
            {
                // If we don't know the user's name yet, their first message is their name
                if (!key.HasName())
                {
                    ChatInput.AppendText("You: " + input + gap);

                    // A name must be letters only, short, and not one of the bot's commands
                    bool looksLikeCommand = NlpServices.IsShowLog(input) || NlpServices.IsAddTask(input) ||
                                            NlpServices.IsReminder(input) || NlpServices.IsQuiz(input) ||
                                            NlpServices.IsShowTasks(input);

                    if (key.IsValidName(input) && !looksLikeCommand && input.Split(' ').Length <= 3)
                    {
                        key.SetUserName(input);
                        ChatInput.AppendText("GemBot: Nice to meet you, " + key.GetUserName() +
                            "! You can ask me about passwords, phishing, scams, safe browsing, social media and privacy." + gap);
                    }
                    else
                    {
                        ChatInput.AppendText("GemBot: Before I can help with that, please tell me your name (letters only)." + gap);
                    }
                    return;
                }
            


                // Show what the user typed
                ChatInput.AppendText(key.GetUserName() + ": " + input + gap);

                // ---------- 1. Answer to "Would you like a reminder?" ----------
                if (waitingForReminderTaskId != -1)
                {
                    int taskId = waitingForReminderTaskId;
                    string taskTitle = waitingForReminderTitle;
                    waitingForReminderTaskId = -1;   // stop waiting

                    DateTime? answerDate = ReminderParser.GetReminderDate(input);

                    if (NlpServices.IsYes(input) || answerDate != null)
                    {
                        // User said yes but no time, so ask when
                        if (answerDate == null)
                        {
                            ChatInput.AppendText("GemBot: When should I remind you? You can say \"in 3 days\" or \"tomorrow\"." + gap);
                            waitingForReminderTaskId = taskId;   // keep waiting
                            return;
                        }

                        taskRepo.SetReminder(taskId, answerDate.Value);
                        ChatInput.AppendText("GemBot: Got it! I'll remind you about '" + taskTitle + "' on " + answerDate.Value.ToString("dd MMM yyyy") + "." + gap);
                        log.Add("Reminder set: '" + taskTitle + "' on " + answerDate.Value.ToString("dd MMM yyyy"));
                        return;
                    }

                    if (input.ToLower().StartsWith("no"))
                    {
                        ChatInput.AppendText("GemBot: No problem, I won't set a reminder for '" + taskTitle + "'." + gap);
                        return;
                    }
                    // Anything else: carry on and treat it as a normal message
                }

                // ---------- 2. Reminders, e.g. "Remind me to update my password tomorrow" ----------
                if (NlpServices.IsReminder(input))
                {
                    string title = NlpServices.GetTaskTitle(input);
                    if (title == "")
                    {
                        ChatInput.AppendText("GemBot: What should I remind you about? For example: \"Remind me to update my password tomorrow\"." + gap);
                        return;
                    }

                    DateTime? date = ReminderParser.GetReminderDate(input);
                    int newId = taskRepo.AddTask(title, NlpServices.GetDescription(title), date);

                    if (date != null)
                    {
                        ChatInput.AppendText("GemBot: Reminder set for '" + title + "' on " + date.Value.ToString("dd MMM yyyy") + "." + gap);
                        log.Add("Reminder set: '" + title + "' on " + date.Value.ToString("dd MMM yyyy"));
                    }
                    else
                    {
                        ChatInput.AppendText("GemBot: I've added '" + title + "'. When should I remind you? (e.g. \"in 3 days\")" + gap);
                        log.Add("Task added: '" + title + "' (no reminder set yet)");
                        waitingForReminderTaskId = newId;
                        waitingForReminderTitle = title;
                    }
                    return;
                }

                // ---------- 3. Adding a task, e.g. "Add task - Review privacy settings" ----------
                if (NlpServices.IsAddTask(input))
                {
                    string title = NlpServices.GetTaskTitle(input);
                    if (title == "")
                    {
                        ChatInput.AppendText("GemBot: What is the task? For example: \"Add task - Review privacy settings\"." + gap);
                        return;
                    }

                    string description = NlpServices.GetDescription(title);
                    DateTime? date = ReminderParser.GetReminderDate(input);
                    int newId = taskRepo.AddTask(title, description, date);

                    if (date != null)
                    {
                        ChatInput.AppendText("GemBot: Task added: '" + title + "' with a reminder on " + date.Value.ToString("dd MMM yyyy") + "." + gap);
                        log.Add("Task added: '" + title + "' (reminder on " + date.Value.ToString("dd MMM yyyy") + ")");
                    }
                    else
                    {
                        ChatInput.AppendText("GemBot: Task added with the description \"" + description + "\" Would you like a reminder?" + gap);
                        log.Add("Task added: '" + title + "' (no reminder set)");
                        waitingForReminderTaskId = newId;
                        waitingForReminderTitle = title;
                    }
                    return;
                }

                // ---------- 4. Show tasks ----------
                if (NlpServices.IsShowTasks(input))
                {
                    List<TaskItems> tasks = taskRepo.GetAllTasks();
                    if (tasks.Count == 0)
                    {
                        ChatInput.AppendText("GemBot: You don't have any tasks yet. Try \"Add task - Enable 2FA\"." + gap);
                        return;
                    }

                    string list = "GemBot: Here are your tasks:" + Environment.NewLine;
                    int number = 1;
                    foreach (TaskItems task in tasks)
                    {
                        string status = task.IsCompleted ? "done" : "not done";
                        string reminder = task.ReminderDate == null ? "no reminder" : "reminder " + task.ReminderDate.Value.ToString("dd MMM yyyy");
                        list += "  " + number + ". " + task.Title + " (" + status + ", " + reminder + ")" + Environment.NewLine;
                        number++;
                    }
                    ChatInput.AppendText(list + Environment.NewLine);
                    return;
                }

                // ---------- 5. Quiz ----------
                if (NlpServices.IsQuiz(input))
                {
                    ChatInput.AppendText("GemBot: Let's test your cybersecurity knowledge! Opening the Quiz tab for you..." + gap);
                    log.Add("Quiz opened from the chat");
                    tabControl2.SelectedTab = tabQuiz;
                    return;
                }

                // ---------- 6. Full activity log ("show more") ----------
                if (NlpServices.IsShowMore(input))
                {
                    List<string> all = log.GetAll();
                    if (all.Count == 0)
                    {
                        ChatInput.AppendText("GemBot: I haven't done anything yet." + gap);
                        return;
                    }

                    string text = "GemBot: Here is the full history:" + Environment.NewLine;
                    for (int i = 0; i < all.Count; i++)
                    {
                        text += "  " + (i + 1) + ". " + all[i] + Environment.NewLine;
                    }
                    ChatInput.AppendText(text + Environment.NewLine);
                    return;
                }

                // ---------- 7. Recent activity log (last 5 actions) ----------
                if (NlpServices.IsShowLog(input))
                {
                    List<string> recent = log.GetRecent(5);
                    if (recent.Count == 0)
                    {
                        ChatInput.AppendText("GemBot: I haven't done anything yet." + gap);
                        return;
                    }

                    string text = "GemBot: Here's a summary of recent actions:" + Environment.NewLine;
                    for (int i = 0; i < recent.Count; i++)
                    {
                        text += "  " + (i + 1) + ". " + recent[i] + Environment.NewLine;
                    }
                    if (log.GetAll().Count > recent.Count)
                    {
                        text += "  Type \"show more\" to see the full history." + Environment.NewLine;
                    }
                    ChatInput.AppendText(text + Environment.NewLine);
                    return;
                }

                // ---------- 8. Everything else: your Part 2 chatbot answers ----------
                string reply = key.GetResponse(input);
                ChatInput.AppendText("GemBot: " + reply + gap);

                // Log the advice it gave (but not when it didn't understand)
                if (!reply.StartsWith("I'm not sure"))
                {
                    log.Add("Gave cybersecurity advice for: '" + input + "'");
                }
            }
            catch (Exception)
            {
                ChatInput.AppendText("GemBot: Oops, something went wrong. Please try again." + gap);
            }
        }

        private void ChatInput_TextChanged(object sender, EventArgs e)
        {


        }

        private void ChatInput2_TextChanged(object sender, EventArgs e)
        {



            // Only allow sending when the user has typed something 
            if (ChatInput2.Text.Trim() == "")
            {
                button2.Enabled = false;   // nothing typed - grey out the Send button
            }
            else
            {
                button2.Enabled = true;    // text typed - Send button can be clicked
            }
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabQuiz_Click(object sender, EventArgs e)
        {

        }

        private void tabChat_Click(object sender, EventArgs e)
        {

        }
        private void tabTask_Click(object sender, EventArgs e)
        {

        }
        // Runs every time the user opens the Task Assistant tab - loads the tasks from the database
        private void tabTask_Enter(object sender, EventArgs e)
        {
            try
            {
                List<TaskItems> tasks = taskRepo.GetAllTasks();
                dgvTasks.DataSource = tasks;

                // Hide the id column and give the other columns friendly names
                dgvTasks.Columns["Id"].Visible = false;
                dgvTasks.Columns["ReminderDate"].HeaderText = "Reminder";
                dgvTasks.Columns["IsCompleted"].HeaderText = "Completed";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the tasks from the database.\n" + ex.Message, "Database error");
            }
        }

        // ADD TASK button
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTaskTitle.Text.Trim();
            string description = txtTaskDescription.Text.Trim();

            // A task must have a title
            if (title == "")
            {
                MessageBox.Show("Please enter a task title.", "Task Assistant");
               
                return;
            }


            // The database needs a description, so use a default one if it is empty
            if (description == "")
            {
                description = "No description added.";
            }

            // The reminder is only used if the checkbox is ticked
            DateTime? reminder = null;
            if (chkReminder.Checked)
            {
                if (dtpReminder.Value.Date < DateTime.Today)
                {
                    MessageBox.Show("The reminder date can't be in the past.", "Task Assistant");
                    return;
                }
                reminder = dtpReminder.Value.Date;
            }

            try
            {
                taskRepo.AddTask(title, description, reminder);
                MessageBox.Show("Task added: " + title, "Task Assistant");
                log.Add("Task added: '" + title + "'" + (reminder == null ? " (no reminder set)" : " (reminder on " + reminder.Value.ToString("dd MMM yyyy") + ")"));

                // Clear the boxes for the next task
                txtTaskTitle.Clear();
                txtTaskDescription.Clear();
                chkReminder.Checked = false;

                tabTask_Enter(sender, e);   // reload the list so the new task shows
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save the task.\n" + ex.Message, "Database error");
            }
        }

        // MARK COMPLETE button
        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            // The user must click a task in the list first
            if (dgvTasks.CurrentRow == null)
            {
                MessageBox.Show("Please select a task first.", "Task Assistant");
              
                return;
            }

            TaskItems task = (TaskItems)dgvTasks.CurrentRow.DataBoundItem;

            if (task.IsCompleted)
            {
                MessageBox.Show("This task is already completed.", "Task Assistant");
                return;
            }

            try
            {
                taskRepo.MarkComplete(task.Id);
                log.Add("Task completed: '" + task.Title + "'");
                MessageBox.Show("Well done! '" + task.Title + "' is marked as completed.", "Task Assistant");
                tabTask_Enter(sender, e);   // reload the list
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update the task.\n" + ex.Message, "Database error");
            }
        }

        // DELETE TASK button
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null)
            {
                MessageBox.Show("Please select a task first.", "Task Assistant");
             
                return;
            }

            TaskItems task = (TaskItems)dgvTasks.CurrentRow.DataBoundItem;

            // Ask before deleting, in case the user clicked by mistake
            DialogResult answer = MessageBox.Show("Delete '" + task.Title + "'?", "Delete task", MessageBoxButtons.YesNo);
            if (answer == DialogResult.No)
            {
                return;
            }

            try
            {
                taskRepo.DeleteTask(task.Id);
                log.Add("Task deleted: '" + task.Title + "'");
                tabTask_Enter(sender, e);   // reload the list
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete the task.\n" + ex.Message, "Database error");
            }
        }
    }
}