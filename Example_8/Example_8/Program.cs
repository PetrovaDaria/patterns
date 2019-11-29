using System;
using System.Collections.Generic;
using System.Drawing;
using Example_8.Figures;
using Example_8.Visitor;
using Rectangle = Example_8.Figures.Rectangle;

namespace Example_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle= new Triangle(3, 4, 5);
            var rectangle = new Rectangle(4, 5);
            var circle = new Circle(3);
            var figures = new List<Figure> {triangle, rectangle, circle};

            var perimeterVisitor = new PerimeterVisitor();
            var areaVisitor = new AreaVisitor();
            var drawVisitor = new DrawVisitor(100, 100, Color.Orchid);
            foreach (var figure in figures)
            {
                figure.Accept(perimeterVisitor);
                figure.Accept(areaVisitor);
                figure.Accept(drawVisitor);
            }
        }
    }
}
