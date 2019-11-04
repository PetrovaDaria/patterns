using System;

// Обобщение
// ReSharper disable once CheckNamespace
namespace Example_01.UmlExamples.Ex2
{
    public abstract class Human
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class Student : Human
    {
        public string Number;
        public string Group;
    }

    public class Professor : Human
    {
    }
}
