namespace Example_03.ClassicBuilders
{
    public interface IClassicBuilder
    {
        IClassicBuilder SetFileName(string name);
        IClassicBuilder SetBody(string text);
        File Result { get; }
    }

    public class PdfClassicBuilder : IClassicBuilder
    {
        private string _name;
        private string _text;

        public IClassicBuilder SetFileName(string name)
        {
            _name = name + ".pdf";
            return this;
        }

        public IClassicBuilder SetBody(string text)
        {
            _text = text;
            return this;
        }

        public File Result => new File {Name = _name, Text = _text};
    }

    public class XlsxClassicBuilder : IClassicBuilder
    {
        private string _name;
        private string _text;

        public IClassicBuilder SetFileName(string name)
        {
            _name = name + ".xlsx";
            return this;
        }

        public IClassicBuilder SetBody(string text)
        {
            _text = text;
            return this;
        }

        public File Result => new File {Name = _name, Text = _text};
    }

    public class ClassicBuilderDirector
    {
        private readonly IClassicBuilder _classicBuilder;

        public ClassicBuilderDirector(IClassicBuilder classicBuilder)
        {
            _classicBuilder = classicBuilder;
        }

        public void Build(string name, string text)
        {
            _classicBuilder.SetFileName(name);
            _classicBuilder.SetBody(text);
        }
    }

    public class File
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
