using System;

namespace Example__05.ChatClient
{
    public class Message
    {
        public string Author { get; }
        public string Recipient { get;  }
        public string Text { get; }

        public Message(string author, string recipient, string text)
        {
            Author = author;
            Recipient = recipient;
            Text = text;
        }
    }
}
