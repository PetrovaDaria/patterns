// Ассоциация
// ReSharper disable once CheckNamespace
namespace Example_01.UmlExamples.Ex4
{
    public class Student
    {
        public Audience Audience { get; set; }
    }

    public class Audience
    {
        public int Id { get; set; }
        public string Number { get; set; }
    }
}