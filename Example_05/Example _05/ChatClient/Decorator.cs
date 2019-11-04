using System;
using System.Collections.Generic;

namespace Example__05.ChatClient
{
    public class ChatClientDecoratorBase : IChatClient
    {
        public override string Login { get; }
        private List<Message> _messages;

        protected readonly IChatClient Decoratee;

        protected ChatClientDecoratorBase(IChatClient decoratee)
        {
            Decoratee = decoratee;
            Login = Decoratee.Login;
        }

        protected virtual Message OnBeforeSendMessage(Message message)
        {
            return message;
        }

        protected virtual List<Message> OnBeforeGetMessages()
        {
            return _messages;
        }

        public override void SendMessage(Message message)
        {
            var newMessage = OnBeforeSendMessage(message);
            Decoratee.SendMessage(newMessage);
        }

        public override List<string> GetMessages()
        {
            return Decoratee.GetMessages();
        }
    }

    public class CypherDecorator : ChatClientDecoratorBase
    {
        public CypherDecorator(IChatClient decoratee) : base(decoratee)
        {

        }

        protected override Message OnBeforeSendMessage(Message message)
        {
            var cypheredText = $"<зашифровано>{message.Text}</зашифровано>";
            var newMessage = new Message(message.Author, message.Recipient, cypheredText);
            return base.OnBeforeSendMessage(newMessage);
        }
    }

    public class NameShadowDecorator : ChatClientDecoratorBase
    {
        public NameShadowDecorator(IChatClient decoratee) : base(decoratee)
        {

        }

        protected override List<Message> OnBeforeGetMessages()
        {
            var newMessages = new List<Message>();
            _messages.ForEach(message =>
            {
                var shadowedAuthor = shadowName(message.Author);
                var shadowedRecipient = shadowName(message.Recipient);
                var newMessage = new Message(shadowedAuthor, shadowedRecipient, message.Text);
                newMessages.Add(newMessage);
            });
            return base.OnBeforeGetMessages();
        }

        private string shadowName(string name)
        {
            return name.GetHashCode().ToString();
        }
    }
}
