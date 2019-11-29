using Example_8.Visitor;

namespace Example_8.Figures
{
    public class Rectangle : Figure
    {
        public override string Name => "Rectangle";

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        public int Width;
        public int Height;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
