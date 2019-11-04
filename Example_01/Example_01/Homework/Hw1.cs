using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Example_01.Homework.Hw1
{
    public interface ILeg
    {
        int Height { get; set; }
    }

    public class WoodenLeg : ILeg
    {
        public int Height { get; set; }
    }

    public class MetalLeg : ILeg
    {
        public int Height { get; set; }
    }

    public interface IFurniture
    {
        int Length { get; }
        int Width { get; }
        int Weight { get; }
        IEnumerable<ILeg> Legs { get; }
        Factory Factory { get; }
    }

    public class Table : IFurniture
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Weight { get; set; }
        public IEnumerable<ILeg> Legs { get; set; }
        public Factory Factory { get; set; }
    }

    public class Factory
    {
        public string Uid { get; set; }
        public string Name { get; set; }
    }
}