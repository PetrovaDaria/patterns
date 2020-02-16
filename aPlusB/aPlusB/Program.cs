using System;

namespace aPlusB
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ');
            var a = int.Parse(numbers[0]);
            var b = int.Parse(numbers[1]);
            Console.WriteLine(a + b);
        }
    }
}
