using Example_8.Figures;

namespace Example_8.Visitor
{
    public interface IVisitor
    {
        void Visit(Triangle triangle);
        void Visit(Rectangle rectangle);
        void Visit(Circle circle);
    }
}
