using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CyberSecurityPart2
{
    public partial class Form1 : Form
    {

        private string userName = "";
        private string lastTopic = "";
        private string favouriteTopic = "";
        private Random rng = new Random();
        
        ChatEngine key = new ChatEngine();
        public Form1()
        {
            InitializeComponent();
            ChatInput_TextChanged(this, EventArgs.Empty);

            PlaySound();
            LoadImage();

            //POPULATING THE KEYWORD RESPONSES FOR THE CHATBOT
          
            key.keywordResponses["Password"] = new List<string> { "Use strong passwords with at least 12 characters, including uppercase, lowercase, numbers, and symbols. Never reuse passwords!"};
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
        private void button2_Click(object sender, EventArgs e)
        {
            string input = ChatInput2.Text.Trim();   // get what the user typed
            ChatInput2.Clear();                      // empty the typing box
            ChatInput2.Focus();                      // put the cursor back in the typing box

            // Input validation: don't allow empty messages
            if (input == "")
            {
                AddToChat("GemBot", "Please type a message first.");
                return;
            }

            // try/catch so the chatbot never crashes on unexpected input
            try
            {
                // If we don't know the user's name yet, their first message is their name
                if (!key.HasName())
                {
                    AddToChat("You", input);

                    if (key.IsValidName(input))
                    {
                        key.SetUserName(input);
                        AddToChat("GemBot", "Nice to meet you, " + key.GetUserName() +
                            "! You can ask me about passwords, phishing, safe browsing, social media and privacy.");
                    }
                    else
                    {
                        AddToChat("GemBot", "Please enter a valid name using letters only.");
                    }
                    return;
                }

                // We know the name, so the ChatEngine decides the reply
                AddToChat(key.GetUserName(), input);
                AddToChat("GemBot", key.GetResponse(input));
            }
            catch (Exception)
            {
                AddToChat("GemBot", "Oops, something went wrong. Please try again.");
            }
        }

        // Adds one message to the big chat box (ChatInput) and scrolls down to it
        private void AddToChat(string who, string message)
        {
            ChatInput.AppendText(who + ": " + message + Environment.NewLine + Environment.NewLine);
            ChatInput.ScrollToCaret();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StyleForm();
            ShowAsciiArt();
            
            ChatInput.ReadOnly = true;

            // Welcome the user and ask for their name straight away
            AddToChat("GemBot", "Hello! Welcome to the Cybersecurity Awareness Assistant.");
            AddToChat("GemBot", "Before we start, what is your name?");

            // Put the cursor in the typing box so the user can type right away
            ChatInput2.Focus();
        }

        private void ChatInput_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ChatInput_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void ChatInput2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Shows the ASCII art from Part 1 at the top of the window
        private void ShowAsciiArt()
        {
            Label asciiLabel = new Label();

        
            asciiLabel.Text =
        @"  ____                 ____        _
 / ___| ___ _ __ ___  | __ )  ___ | |_
| |  _ / _ \ '_ ` _ \ |  _ \ / _ \| __|
| |_| |  __/ | | | | || |_) | (_) | |_
 \____|\___|_| |_| |_||____/ \___/ \__|";

            asciiLabel.Font = new Font("Consolas", 9);   // Consolas keeps all letters the same width, so the art lines up
            asciiLabel.AutoSize = true;
            asciiLabel.Location = new Point(ChatInput.Left, 20);   // line it up with the left side of the chat box

            this.Controls.Add(asciiLabel);   // put the label on the form
        }
        // Gives the form colours, fonts and neat spacing 
        private void StyleForm()
        {
            // ---- Colours (dark purple theme ) ----
            Color background = Color.FromArgb(24, 20, 45);     // dark purple-navy
            Color chatBoxColour = Color.FromArgb(38, 33, 68);  // slightly lighter for the chat box
            Color accent = Color.FromArgb(214, 130, 220);      // pink-purple, like the logo

            // ---- The window ----
            this.BackColor = background;
            this.ForeColor = accent;        // labels (like the ASCII art) use this colour
            this.AcceptButton = button2;    // pressing Enter clicks Send

            // ---- Big chat box ----
            ChatInput.BackColor = chatBoxColour;
            ChatInput.ForeColor = Color.White;
            ChatInput.Font = new Font("Segoe UI", 10);
            ChatInput.BorderStyle = BorderStyle.None;

            // ---- Typing box: same width as the chat box, leaving room for the button ----
            ChatInput2.Font = new Font("Segoe UI", 11);
            ChatInput2.Left = ChatInput.Left;
            ChatInput2.Top = ChatInput.Bottom + 15;
            ChatInput2.Width = ChatInput.Width - 110;

            // ---- Send button: sits right next to the typing box ----
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
        }
    }
}
