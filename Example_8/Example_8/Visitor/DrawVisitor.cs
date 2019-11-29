using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Example_8.Figures;
using Rectangle = Example_8.Figures.Rectangle;

namespace Example_8.Visitor
{
    public class DrawVisitor : IVisitor
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Color Color { get; set; }

        public DrawVisitor(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
        public void Visit(Triangle triangle)
        {
            var pen = new Pen(Color);
            var image = new Bitmap(500, 500);
            var g = Graphics.FromImage(image);
            g.DrawRectangle(pen, X, Y, triangle.FirstSide, triangle.SecondSide);
            g.DrawImage(image, 0, 0);
            Console.WriteLine("Draw "+ triangle.Name);
        }

        public void Visit(Rectangle rectangle)
        {
            var pen = new Pen(Color);
            var image = new Bitmap(500, 500);
            var g = Graphics.FromImage(image);
            g.DrawRectangle(pen, X, Y, rectangle.Width, rectangle.Height);
            g.DrawImage(image, 0, 0);
            Console.WriteLine("Draw "+ rectangle.Name);
        }

        public void Visit(Circle circle)
        {
            var pen = new Pen(Color);
            var image = new Bitmap(500, 500);
            var g = Graphics.FromImage(image);
            g.DrawEllipse(pen, X, Y, circle.Radius, circle.Radius);
            g.DrawImage(image, 0, 0);
            Console.WriteLine("Draw "+ circle.Name);
        }
    }
}
