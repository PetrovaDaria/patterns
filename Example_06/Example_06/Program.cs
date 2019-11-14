using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example_06.ChainOfResponsibility;

namespace Example_06
{
    class Program
    {
        static void Main(string[] args)
        {
            var bancomat = new MyBankomat();
            Console.WriteLine(bancomat.Cash("2050 рублей"));
            Console.WriteLine(bancomat.Cash("2033$"));
        }
    }
}
