using Example_8.Visitor;

namespace Example_8.Figures
{
    public class Circle : Figure
    {
        public override string Name => "Circle";

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        public int Radius;

        public Circle(int radius)
        {
            Radius = radius;
        }
    }
}
