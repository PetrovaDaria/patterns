using System;
using Example_8.Visitor;

namespace Example_8.Figures
{
    public class Triangle : Figure
    {
        public int FirstSide;
        public int SecondSide;
        public int ThirdSide;

        public override string Name => "Triangle";

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        public Triangle(int first, int second, int third)
        {
            FirstSide = first;
            SecondSide = second;
            ThirdSide = third;
        }
    }
}
