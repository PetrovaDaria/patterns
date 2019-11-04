using System.Collections.Generic;

namespace Example__05.ChatClient
{
    public abstract class IChatClient
    {
        public abstract string Login { get; }
        protected List<Message> _messages;
        public abstract void SendMessage(Message message);
        public abstract List<string> GetMessages();
    }
}
