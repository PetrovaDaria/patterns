namespace Example__05.ChatClient
{
    public class Message
    {
        public string From;
        public string To;
        public string Text;

        public Message(string from, string to, string text)
        {
            From = from;
            To = to;
            Text = text;
        }
    }
}
