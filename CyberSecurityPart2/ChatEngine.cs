using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityPart2
{
    
    internal class ChatEngine
    {
        // ==================== MEMORY (your original fields) ====================
        private string userName = "";        // the user's name
        private string favouriteTopic = "";  // the word the user said they are interested in, e.g. "privacy"
        private string lastTopic = "";       // the dictionary key we are talking about right now
        private Random rng = new Random();   // used to pick random responses

        // Remembers the dictionary key of the favourite topic (so we can personalise tips)
        private string favouriteKey = "";

        // Remembers the last reply, so we don't give the same tip twice in a row
        private string lastResponse = "";

       
        public Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>();

        // ==================== EXTRA LISTS FOR PART 2 ====================

        private Dictionary<string, string> sentimentWords = new Dictionary<string, string>()
        {
            { "worried", "worried" }, { "scared", "worried" }, { "afraid", "worried" }, { "nervous", "worried" },
            { "curious", "curious" }, { "wondering", "curious" },
            { "frustrated", "frustrated" }, { "annoyed", "frustrated" }, { "angry", "frustrated" },
            { "overwhelmed", "overwhelmed" }, { "unsure", "overwhelmed" }
        };

        // Mood name -> what the bot says for that mood
        private Dictionary<string, string> sentimentReplies = new Dictionary<string, string>()
        {
            { "worried", "It's completely understandable to feel that way. Scammers can be very convincing. Let me share a tip to help you stay safe:" },
            { "curious", "I love your curiosity! Learning about cybersecurity is the best way to protect yourself. Here's something useful:" },
            { "frustrated", "I'm sorry this feels frustrating. Let's take it one small step at a time. Here's a simple tip:" },
            { "overwhelmed", "Don't worry, you don't have to learn everything at once. Here's just one easy tip to start with:" }
        };

        // Phrases that mean "carry on with the same topic"
        private List<string> followUpPhrases = new List<string>()
        {
            "tell me more", "another tip", "give me another", "explain more", "more tips", "next tip", "go on"
        };

        // Phrases that show the user is confused
        private List<string> confusedPhrases = new List<string>()
        {
            "confused", "don't understand", "dont understand", "don't get it", "dont get it", "what do you mean"
        };

        // ==================== NAME METHODS ====================

        // True if we already know the user's name
        public bool HasName()
        {
            return userName != "";
        }

        public string GetUserName()
        {
            return userName;
        }

        // Saves the name with a capital first letter ("thabo" -> "Thabo")
        public void SetUserName(string name)
        {
            name = name.Trim();
            userName = char.ToUpper(name[0]) + name.Substring(1);
        }

        // A valid name is not empty and only has letters or spaces
        public bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        // ==================== MAIN METHOD ====================
        
        public string GetResponse(string input)
        {
            // ---- 1. Empty input ----
            if (string.IsNullOrWhiteSpace(input))
            {
                return "You didn't type anything. Try asking me about passwords, phishing or privacy.";
            }

            // Lowercase so "PASSWORD" and "password" are treated the same
            string text = input.ToLower().Trim();

            // Look for a keyword and a mood in what the user typed
            string matchedWord;
            string key = FindKey(text, out matchedWord);
            string mood = FindMood(text);

            // ---- MEMORY: user tells us their favourite topic ----
            // e.g. "I'm interested in privacy"
            if (text.Contains("interested in") && key != "")
            {
                favouriteTopic = matchedWord;   // remember the word, e.g. "privacy"
                favouriteKey = key;             // remember which list it belongs to
                return "Great! I'll remember that you're interested in " + favouriteTopic +
                       ". It's a crucial part of staying safe online. " + GetRandomResponse(key);
            }

            // ----  MEMORY: user asks what we remember ----
            if (text.Contains("what is my name") || text.Contains("what's my name"))
            {
                return "Your name is " + userName + "!";
            }
            if (text.Contains("what am i interested in") || text.Contains("my favourite topic"))
            {
                if (favouriteTopic == "")
                {
                    return "You haven't told me yet. Try saying \"I'm interested in privacy\".";
                }
                return "You told me you're interested in " + favouriteTopic + ".";
            }

            // ----SENTIMENT: user shows a mood ----
            if (mood != "")
            {
                // Pick a topic for the tip: this message -> current topic -> favourite -> any topic
                string tipKey = key;
                if (tipKey == "") tipKey = lastTopic;
                if (tipKey == "") tipKey = favouriteKey;
                if (tipKey == "") tipKey = GetAnyKey();

                
                
                return "Thank you for sharing, " + userName + ". " + sentimentReplies[mood] + " " + GetRandomResponse(tipKey);
            }

            // ----  KEYWORD RECOGNITION ----
            if (key != "")
            {
                return GetRandomResponse(key);
            }

            // ----  CONVERSATION FLOW: user is confused ----
            if (ContainsAny(text, confusedPhrases))
            {
                if (lastTopic != "")
                {
                    return "No problem, let me explain it another way. " + GetRandomResponse(lastTopic);
                }
                return "No problem! Which topic should I explain? Try passwords, phishing or privacy.";
            }

            // ---- CONVERSATION FLOW: "tell me more", "another tip" ----
            if (ContainsAny(text, followUpPhrases))
            {
                if (lastTopic != "")
                {
                    return "Sure, here's more: " + GetRandomResponse(lastTopic);
                }
                return "We haven't picked a topic yet. Try asking about passwords, phishing or privacy.";
            }

            // ---- ERROR HANDLING: nothing matched ----
            return "I'm not sure I understand. Can you try rephrasing?";
        }

        // ==================== HELPER METHODS ====================

        // Picks a random response from a key's list (random responses requirement)
        private string GetRandomResponse(string key)
        {
            List<string> responses = keywordResponses[key];
            string reply = responses[rng.Next(responses.Count)];

            // If there is more than one response
            if (responses.Count > 1)
            {
                while (reply == lastResponse)
                {
                    reply = responses[rng.Next(responses.Count)];
                }
            }

            lastResponse = reply;
            lastTopic = key;   // remember the topic so "tell me more" works

            // Personalise if this is the user's favourite topic (memory and recall)
            if (key == favouriteKey && favouriteTopic != "")
            {
                return "As someone interested in " + favouriteTopic + ", you might like this: " + reply;
            }
            return reply;
        }

        private string FindKey(string text, out string matchedWord)
        {
            foreach (string key in keywordResponses.Keys)
            {
                string[] words = key.Split(',');

                foreach (string word in words)
                {
                    string cleanWord = word.Trim().ToLower();

                    if (cleanWord != "" && text.Contains(cleanWord))
                    {
                        matchedWord = cleanWord;
                        return key;
                    }
                }
            }

            matchedWord = "";
            return "";
        }

        // Returns the mood found in the text, or "" if there is none
        private string FindMood(string text)
        {
            foreach (string word in sentimentWords.Keys)
            {
                if (text.Contains(word))
                {
                    return sentimentWords[word];
                }
            }
            return "";
        }

        // True if the text contains any phrase from the list
        private bool ContainsAny(string text, List<string> phrases)
        {
            foreach (string phrase in phrases)
            {
                if (text.Contains(phrase))
                {
                    return true;
                }
            }
            return false;
        }

        // Returns the first key in the dictionary (used when a mood is shown but no topic)
        private string GetAnyKey()
        {
            foreach (string key in keywordResponses.Keys)
            {
                return key;
            }
            return "";
        }
    }
}