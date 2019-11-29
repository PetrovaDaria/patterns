using Example_8.Visitor;

namespace Example_8.Figures
{
    public abstract class Figure
    {
        public abstract string Name { get; }

        public abstract void Accept(IVisitor v);
    }
}
