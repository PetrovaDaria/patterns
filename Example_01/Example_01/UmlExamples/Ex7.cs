// Зависимость
// ReSharper disable once CheckNamespace
namespace Example_01.UmlExamples.Ex7
{
    public class Student
    {                   
        public string Name { get; set; }
        public string Number { get; set; }
    }

    public class StudentFilter
    {
        public Student[] Filter(Student[] students, string name)
        {
            return new Student[0];
        }
    }
}
