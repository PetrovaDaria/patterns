using System;
using System.Collections.Generic;
using Example_02.AbstractFactoryExample;
using Example_02.FactoryMethodExample;
using Example_02.PrototypeExample;
using Example_02.SingletonExample;

namespace Example_02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Runner.Run();
            //AbstractFactoryExample();
            //PrototypeExample();

            Console.ReadKey();
        }

        #region AbstractFactoryExample

        public static void AbstractFactoryExample()
        {
            //Меню на понедельник
            var mondayFactory = new MondayFactory();
            PrintMenu(mondayFactory);

            //Меню на вторник
            var tuesdayFactory = new TuesdayFactory();
            PrintMenu(tuesdayFactory);

            //Меню на вторник
            //PrintMenu(WeekDay.Tuesday);
        }

        public static void PrintMenu(ILunchFactory factory)
        {
            Console.WriteLine("==== Меню на сегодня ======");

            var dish = factory.CreateHotDish();
            Console.WriteLine($"Основное блюдо: {dish.Name}");

            var dessert = factory.CreateDessert();
            Console.WriteLine($"Дессерт: {dessert.Name}");
        }

        public static void PrintMenu(WeekDay weekDay)
        {
            var factory = LunchFactoryHelper.Create(weekDay);
            PrintMenu(factory);
        }

        #endregion

        #region PrototypeExample

        public static void PrototypeExample()
        {
            var prototypes = new Dictionary<int, Prototype>
            {
                {1, new ConcretePrototype1("ConcretePrototype_1")},
                {2, new ConcretePrototype2("ConcretePrototype_2")}
            };

            Prototype prototype;
            prototypes.TryGetValue(2, out prototype);
            if (prototype != null)
            {
                Console.WriteLine(prototype.Id);
            }
        }

        #endregion
    }
}
