using System;
using System.Collections.Generic;

// Композиция
// ReSharper disable once CheckNamespace
namespace Example_01.UmlExamples.Ex6
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

    public class History
    {
        public Student Student { get; set; }
        public Group Group { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
