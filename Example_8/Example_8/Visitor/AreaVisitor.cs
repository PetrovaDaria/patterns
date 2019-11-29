using System;
using Example_8.Figures;

namespace Example_8.Visitor
{
    public class AreaVisitor : IVisitor
    {
        public void Visit(Triangle triangle)
        {
            var halfPerimeter = (triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide) / 2;
            var area = Math.Sqrt(halfPerimeter * (halfPerimeter - triangle.FirstSide) *
                             (halfPerimeter - triangle.SecondSide) * (halfPerimeter - triangle.ThirdSide));

            Console.WriteLine("Area of " + triangle.Name + " is " + area);
        }

        public void Visit(Rectangle rectangle)
        {
            var area = rectangle.Width * rectangle.Height;
            Console.WriteLine("Area of " + rectangle.Name + " is " + area);
        }

        public void Visit(Circle circle)
        {
            var area = Math.PI * circle.Radius * circle.Radius;
            Console.WriteLine("Area of " + circle.Name + " is " + area);
        }
    }
}
