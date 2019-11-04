using System.Collections.Generic;

// Агрегация
// ReSharper disable once CheckNamespace
namespace Example_01.UmlExamples.Ex5
{
    public class Group
    {
        public List<Student> Students { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
