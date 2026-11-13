using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CyberSecurityPart2.SERVICES
{
    internal class ReminderParser
    {
        // Words for numbers, so "in three days" works as well as "in 3 days"
        private static Dictionary<string, int> numberWords = new Dictionary<string, int>()
        {
            { "a", 1 }, { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 },
            { "five", 5 }, { "six", 6 }, { "seven", 7 }, { "ten", 10 }
        };

        // Reads the user's text and works out the reminder date.
        // Returns null if the text has no time in it.
        public static DateTime? GetReminderDate(string text)
        {
            text = text.ToLower();

            // Simple words first
            if (text.Contains("today")) return DateTime.Today;
            if (text.Contains("tomorrow")) return DateTime.Today.AddDays(1);
            if (text.Contains("next week")) return DateTime.Today.AddDays(7);
            if (text.Contains("next month")) return DateTime.Today.AddMonths(1);

            // Regex finds a number (or number word) followed by day, week or month
            
            Match match = Regex.Match(text, @"(\d+|a|one|two|three|four|five|six|seven|ten)\s+(day|week|month)");

            if (match.Success)
            {
                string numberText = match.Groups[1].Value; 
                string unit = match.Groups[2].Value;        

                // Turn the number into an int (either digits or a word)
                int number;
                if (!int.TryParse(numberText, out number))
                {
                    number = numberWords[numberText];
                }

                if (unit == "day") return DateTime.Today.AddDays(number);
                if (unit == "week") return DateTime.Today.AddDays(number * 7);
                return DateTime.Today.AddMonths(number);
            }

            return null;   // no time found
        }
    }
}
