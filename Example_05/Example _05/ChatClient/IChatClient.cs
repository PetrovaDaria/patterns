using System.Collections.Generic;

namespace Example__05.ChatClient
{
    public interface IChatClient
    {
        void SendMessage(Message message);
        List<Message> GetMessages();
    }
}
