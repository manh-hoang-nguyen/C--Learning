using System;

namespace MessengerSample.Helpers
{
    public class LogMessage
    {
        public LogMessage(string text, DateTime timestamp)
        {
            Timestamp = timestamp;
            Text = text;
        }

        public string Text
        {
            get;
            private set;
        }

        public DateTime Timestamp
        {
            get;
            private set;
        }
    }
}