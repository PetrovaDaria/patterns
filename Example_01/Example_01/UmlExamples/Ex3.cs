// Реализация
// ReSharper disable once CheckNamespace
namespace Example_01.UmlExamples.Ex3
{
    public interface Owner
    {
        void Acquire(string property);
        void Dispose(string property);
    }

    public class Person : Owner
    {
        private bool _real;
        private bool _tangible;
        private bool _intangible;

        public void Acquire(string property) { }
        public void Dispose(string property) { }
    }

    public class Corporation : Owner
    {
        private bool _current;
        private bool _fixed;
        private string _longTerm;
        private bool _intangible;

        public void Acquire(string property) { }
        public void Dispose(string property) { }
    }
}
