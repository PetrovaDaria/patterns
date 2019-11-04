namespace Example_03.FluentBuilders
{
    public class CustomStringBuilder
    {
        private string _text;

        public CustomStringBuilder()
        {
            _text = "";
        }

        public CustomStringBuilder Append(string text)
        {
            _text += text;

            return this;
        }

        public CustomStringBuilder AppendLine(string text)
        {
            return Append(text + "\n");
        }

        public CustomStringBuilder AppendFormat(string template, params object[] args)
        {
            return Append(string.Format(template, args));
        }

        public string Result => _text;
    }
}