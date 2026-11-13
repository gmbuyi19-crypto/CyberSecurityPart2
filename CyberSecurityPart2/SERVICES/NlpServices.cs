using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;




namespace CyberSecurityPart2.SERVICES
{
    internal class NlpServices
    {
        // ---------- Lists of phrases (different ways users ask for the same thing) ----------

        private static List<string> addTaskPhrases = new List<string>()
        { "add task", "add a task", "add a new task", "new task", "create a task", "create task", "make a task" };

        private static List<string> reminderPhrases = new List<string>()
        { "remind me", "set a reminder", "set reminder", "add a reminder", "don't let me forget", "dont let me forget" };

        private static List<string> quizPhrases = new List<string>()
        { "quiz", "test me", "test my knowledge", "play a game", "start the game", "mini game" };

        private static List<string> logPhrases = new List<string>()
        { "activity log", "show log", "what have you done", "recent actions", "show history" };

        private static List<string> showMorePhrases = new List<string>()
        { "show more", "show full log", "show all actions", "full history" };

        private static List<string> showTaskPhrases = new List<string>()
        { "show tasks", "show my tasks", "view tasks", "list tasks", "my tasks", "what are my tasks" };

        private static List<string> yesWords = new List<string>()
        { "yes", "yeah", "yep", "sure", "ok", "okay", "please do" };

        // Keyword -> description, used to describe tasks added from the chat
        private static Dictionary<string, string> taskDescriptions = new Dictionary<string, string>()
        {
            { "privacy", "Review account privacy settings to ensure your data is protected." },
            { "2fa", "Turn on two-factor authentication for an extra layer of security on your accounts." },
            { "two-factor", "Turn on two-factor authentication for an extra layer of security on your accounts." },
            { "password", "Change to a strong, unique password and don't reuse it on other accounts." },
            { "phishing", "Learn how to spot phishing emails and report suspicious messages." },
            { "backup", "Back up your important files so you don't lose them to ransomware." },
            { "update", "Install the latest updates so known security holes are fixed." },
            { "antivirus", "Install or update antivirus software to protect your device." }
        };

        // ---------- Checking what the user wants ----------

        // True if the text contains any phrase from the list
        private static bool ContainsAny(string text, List<string> phrases)
        {
            text = text.ToLower();
            foreach (string phrase in phrases)
            {
                if (text.Contains(phrase))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsAddTask(string text) { return ContainsAny(text, addTaskPhrases); }
        public static bool IsReminder(string text) { return ContainsAny(text, reminderPhrases); }
        public static bool IsQuiz(string text) { return ContainsAny(text, quizPhrases); }
        public static bool IsShowLog(string text) { return ContainsAny(text, logPhrases); }
        public static bool IsShowMore(string text) { return ContainsAny(text, showMorePhrases); }
        public static bool IsShowTasks(string text) { return ContainsAny(text, showTaskPhrases); }

        // True if the user is saying yes (e.g. "Yes, remind me in 3 days")
        public static bool IsYes(string text)
        {
            string first = text.ToLower().Trim().Split(' ', ',', '.', '!')[0];
            return yesWords.Contains(first);
        }

        // ---------- Getting the task out of the sentence ----------

        // Add task 
        // Remind me to update my password tomorrow
        public static string GetTaskTitle(string input)
        {
            string lower = input.ToLower();
            string title = input;

            // Longer phrases first, so "add a task to" is cut before "add a task"
            List<string> commandWords = new List<string>()
            {
                "can you remind me to", "please remind me to", "remind me to", "remind me about",
                "set a reminder to", "set a reminder for", "add a reminder to",
                "add a new task to", "add a task to", "add task to", "create a task to",
                "add a new task", "add a task", "add task", "create a task", "create task", "new task", "remind me"
            };

            foreach (string command in commandWords)
            {
                int position = lower.IndexOf(command);
                if (position >= 0)
                {
                    title = input.Substring(position + command.Length);
                    break;
                }
            }

            // Take out the time words, because they belong to the reminder, not the title
            title = Regex.Replace(title, @"\b(today|tomorrow|next week|next month)\b", "", RegexOptions.IgnoreCase);
            title = Regex.Replace(title, @"\bin\s+(\d+|a|one|two|three|four|five|six|seven|ten)\s+(days?|weeks?|months?)\b", "", RegexOptions.IgnoreCase);

            // Remove extra spaces and punctuation at the start and end
            title = title.Trim(' ', '-', ':', '.', '?', '!', ',');

            if (title == "")
            {
                return "";
            }
            return char.ToUpper(title[0]) + title.Substring(1);   // capital first letter
        }

        // Finds a helpful description for the task using its keywords
        public static string GetDescription(string title)
        {
            string lower = title.ToLower();
            foreach (string keyword in taskDescriptions.Keys)
            {
                if (lower.Contains(keyword))
                {
                    return taskDescriptions[keyword];
                }
            }
            return "Cybersecurity task: " + title + ".";
        }
    }
}
