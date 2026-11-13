using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityPart2.SERVICES
{
    internal class QuizService
    {
        // One quiz question
        public class Question
        {
            public string Text;          // the question
            public string[] Options;     // 4 options, or 2 for true/false
            public int CorrectIndex;     // which option is right (0 = first)
            public string Explanation;   // shown after the user answers
        }

        private List<Question> questions = new List<Question>();
        private Random rng = new Random();

        // Different messages so the feedback is not the same every time
        private List<string> correctMessages = new List<string>()
        {
            "Correct!", "Well done!", "Spot on!", "Great job!", "That's right!"
        };

        private List<string> wrongMessages = new List<string>()
        {
            "Not quite.", "Oops, that's not it.", "Good try, but no.", "Incorrect."
        };

        // The constructor fills the list with questions when the quiz is created
        public QuizService()
        {
            AddQuestion("What should you do if you receive an email asking for your password?",
                new string[] { "Reply with your password", "Delete the email", "Report the email as phishing", "Ignore it" },
                2, "Reporting phishing emails helps stop scams from reaching other people.");

            AddQuestion("True or False: It is safe to use the same password for all your accounts.",
                new string[] { "True", "False" },
                1, "If one site is hacked, criminals try that password on all your other accounts.");

            AddQuestion("Which of these is the strongest password?",
                new string[] { "password123", "Thabo1990", "T!g3r$Run#Blue77", "qwerty" },
                2, "Strong passwords are long and mix upper and lower case letters, numbers and symbols.");

            AddQuestion("True or False: A padlock and 'https://' mean the connection to the website is encrypted.",
                new string[] { "True", "False" },
                0, "HTTPS encrypts your data, but still check the address - scammers can use HTTPS too.");

            AddQuestion("What is two-factor authentication (2FA)?",
                new string[] { "Using two passwords", "A second check, like a code sent to your phone", "Logging in on two devices", "Changing your password twice" },
                1, "2FA adds a second step, so a stolen password alone is not enough.");

            AddQuestion("True or False: Your bank may phone you and ask for your OTP to verify your account.",
                new string[] { "True", "False" },
                1, "Banks will never ask for your OTP, PIN or password. Anyone who does is a scammer.");

            AddQuestion("What is social engineering?",
                new string[] { "Building social media apps", "Tricking people into giving away information", "A type of antivirus", "Fixing computer networks" },
                1, "Social engineering targets people, not computers - for example fake calls or messages.");

            AddQuestion("What is the safest way to use public Wi-Fi?",
                new string[] { "Do online banking on it", "Share files with others", "Avoid sensitive logins or use a VPN", "Turn off your firewall" },
                2, "Public Wi-Fi can be watched by others, so avoid banking or use a VPN.");

            AddQuestion("True or False: You should install software updates as soon as possible.",
                new string[] { "True", "False" },
                0, "Updates fix security holes that criminals use to attack devices.");

            AddQuestion("What is ransomware?",
                new string[] { "Software that speeds up your PC", "Malware that locks your files and demands payment", "A free antivirus", "A type of strong password" },
                1, "Regular backups mean you can recover your files without paying criminals.");

            AddQuestion("True or False: It is safe to click a link in an SMS saying you have won a prize.",
                new string[] { "True", "False" },
                1, "Prize messages for competitions you never entered are a common scam.");

            AddQuestion("Someone calls saying they are from IT support and asks for your login details. What should you do?",
                new string[] { "Give them the details", "Hang up and call the official IT number yourself", "Email them your password instead", "Give only your username" },
                1, "Always check a caller's identity through an official number before sharing anything.");
        }

        // Adds one question to the list
        private void AddQuestion(string text, string[] options, int correctIndex, string explanation)
        {
            Question q = new Question();
            q.Text = text;
            q.Options = options;
            q.CorrectIndex = correctIndex;
            q.Explanation = explanation;
            questions.Add(q);
        }

        // How many questions there are
        public int Count()
        {
            return questions.Count;
        }

        // Gets one question by its number (0 = first)
        public Question GetQuestion(int index)
        {
            return questions[index];
        }

        // Picks a random "correct" or "wrong" message
        public string GetFeedback(bool isCorrect)
        {
            if (isCorrect)
            {
                return correctMessages[rng.Next(correctMessages.Count)];
            }
            return wrongMessages[rng.Next(wrongMessages.Count)];
        }

        // Final message depending on the score
        public string GetFinalMessage(int score)
        {
            int total = questions.Count;
            if (score == total) return "Perfect score! You're a cybersecurity pro!";
            if (score >= total * 0.7) return "Great job! You know how to stay safe online.";
            if (score >= total * 0.5) return "Not bad! Review the tips and try again.";
            return "Keep learning to stay safe online!";
        }

    }
}
