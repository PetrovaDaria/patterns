using System;
using System.Collections.Generic;
using System.Linq;

namespace Example__05.ChatClient
{
    public class ChatClient : IChatClient
    {
        private static readonly List<ChatClient> ChatClients;
        public override string Login { get; }
        private List<Message> _messages;

        static ChatClient()
        {
            ChatClients = new List<ChatClient>();
        }

        public ChatClient(string login)
        {
            Login = login;
            ChatClients.Add(this);
            _messages = new List<Message>();
        }

        private void AddMessage(Message message)
        {
            _messages.Add(message);
        }

        public override void SendMessage(Message message)
        {
            ChatClients
                .First(client => client.Login == message.Recipient)
                .AddMessage(message);
        }

        public override List<string> GetMessages()
        {

            return _messages
                .ConvertAll(message =>
                    $"От: {message.Author}\nКому: {message.Recipient}\n{message.Text}");
        }
    }
}
