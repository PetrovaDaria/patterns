using System;
using System.Collections.Generic;

namespace Example_03.EmailBuilder
{
    public class EmailBuilder
    {
        private string recipient;
        private string body;
        private List<string> recipients = new List<string>();
        private string topic;

        public EmailBuilder SetReciever(string recipient)
        {
            this.recipient = recipient;
            return this;
        }

        public EmailBuilder SetBody(string body)
        {
            this.body = body;
            return this;
        }

        public EmailBuilder AddRecipient(string recipient)
        {
            this.recipients.Add(recipient);
            return this;
        }

        public EmailBuilder SetTopic(string topic)
        {
            this.topic = topic;
            return this;
        }

        private string buildRecipients()
        {
            return String.Join(", ", this.recipients.ToArray());
        }

        public string Build()
        {
            if (this.recipient != null && this.body != null)
            {
                return $"Получатель: {recipient}\n{body}\n" +
                       $"Получатели копии: {this.buildRecipients()}\nТема: {this.topic}";
            }
            else
            {
                return "Not correct mail";
            }
        }
    }
}
