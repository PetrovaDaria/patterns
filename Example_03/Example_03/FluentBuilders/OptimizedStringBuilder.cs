using System.Collections.Generic;

namespace Example_03.FluentBuilders
{
    public class OptimizedStringBuilder
    {
        private readonly Queue<char> _text;

        public OptimizedStringBuilder()
        {
            _text = new Queue<char>();
        }

        public OptimizedStringBuilder Append(string text)
        {
            foreach (var chr in text.ToCharArray())
            {
                _text.Enqueue(chr);
            }

            return this;
        }

        public OptimizedStringBuilder AppendLine(string text)
        {
            Append(text);
            _text.Enqueue('\n');

            return this;
        }

        public OptimizedStringBuilder AppendFormat(string template, params object[] args)
        {
            var text = string.Format(template, args);
            return Append(text);
        }

        public string Result => new string(_text.ToArray());
    }
}