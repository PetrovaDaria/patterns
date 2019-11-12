using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Example__05.ChatClient
{
    public abstract class DecoratorBase : IChatClient
    {
        protected readonly IChatClient Decoratee;

        protected DecoratorBase(IChatClient chatClient)
        {
            Decoratee = chatClient;
        }

        public void SendMessage(Message message)
        {
            Decoratee.SendMessage(DecorateSendMessage(message));
        }

        public List<Message> GetMessages()
        {
            return Decoratee
                .GetMessages()
                .Select(DecorateGetMessage)
                .ToList();
        }

        protected abstract Message DecorateSendMessage(Message message);

        protected abstract Message DecorateGetMessage(Message message);
    }

    public class TextCipheringDecorator : DecoratorBase
    {
        public TextCipheringDecorator(IChatClient chatClient) : base(chatClient)
        {
        }
        protected override Message DecorateSendMessage(Message message)
        {
            message.Text = $"<Зашифровано>{message.Text}</Зашифровано>";
            return message;
        }

        protected override Message DecorateGetMessage(Message message)
        {
            var regex = new Regex("(?<=<Зашифровано>)(.*)(?=</Зашифровано>)");
            message.Text = regex.Match(message.Text).Value;
            return message;
        }
    }

    public class NameHidingDecorator : DecoratorBase
    {
        public NameHidingDecorator(IChatClient chatClient) : base(chatClient)
        {
        }
        private string shift(string str, int shift)
        {
            return str.Select(symbol => (int) symbol + 1).ToString();
        }
        protected override Message DecorateSendMessage(Message message)
        {
            message.From = shift(message.From, 1);
            message.To = shift(message.To, 1);
            return message;
        }

        protected override Message DecorateGetMessage(Message message)
        {
            message.From = shift(message.From, -1);
            message.To = shift(message.To, -1);
            return message;
        }
    }
}
