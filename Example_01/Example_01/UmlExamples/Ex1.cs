using System;

// Атрибуты и методы
// ReSharper disable once CheckNamespace
namespace Example_01.UmlExamples.Ex1
{
    public class Human
    {
        public DateTime BirthDay { get; set; }
        public string Name { get; set; }
        private int Height { get; set; }

        public void Say(string text) { }
        public void Sleep() { }
        private void Eat() { }
    }
}
