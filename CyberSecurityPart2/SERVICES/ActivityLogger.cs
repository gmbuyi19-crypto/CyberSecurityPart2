using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CyberSecurityPart2.SERVICES
{
    internal class ActivityLogger
    {
        // Every action the chatbot takes is stored here, with the time it happened
        private List<string> entries = new List<string>();

        // Adds one action to the log, e.g. "13 Nov 14:05 - Task added: 'Enable 2FA'"
        public void Add(string action)
        {
            entries.Add(DateTime.Now.ToString("dd MMM HH:mm") + " - " + action);
        }

        // Gives back only the last few actions 
        public List<string> GetRecent(int count)
        {
            int start = entries.Count - count;
            if (start < 0)
            {
                start = 0;   
            }
            return entries.GetRange(start, entries.Count - start);
        }

        // Gives back the full history 
        public List<string> GetAll()
        {
            return entries;
        }
    }
}
