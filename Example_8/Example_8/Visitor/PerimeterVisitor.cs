using System;
using Example_8.Figures;

namespace Example_8.Visitor
{
    public class PerimeterVisitor : IVisitor
    {
        public void Visit(Triangle triangle)
        {
            var perimeter = triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide;
            Console.WriteLine("Perimeter of " + triangle.Name + " is " + perimeter);
        }

        public void Visit(Rectangle rectangle)
        {
            var perimeter = (rectangle.Height + rectangle.Width) * 2;
            Console.WriteLine("Perimeter of " + rectangle.Name + " is " + perimeter);
        }

        public void Visit(Circle circle)
        {
            var perimeter = 2 * Math.PI * circle.Radius;
            Console.WriteLine("Perimeter of " + circle.Name + " is " + perimeter);
        }
    }
}
