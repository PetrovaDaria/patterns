using System;
using System.Linq;
using Example__05.ChatClient;
using Example__05.Decorator;
using Example__05.Flyweight;

namespace Example__05
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChatClientExample();
            //DecoratorExample();
            //FlyweightExample();
            ChatClientExample();
            Console.ReadKey();
        }

        public static void ChatClientExample()
        {
            IChatClient chatClient = new ChatClient.ChatClient();
            chatClient = new ChatDecoratorBuilder(chatClient)
                .WithTextCiphering()
                .WithNameHiding()
                .Build();
        }

        public static void DecoratorExample()
        {
            //Пустой калькулятор, без дополнительной логики
            ICalculator calculator = new Calcuator();

            //Калькулятор задекорированный логером и таймером
            //calculator = new TimerDecorator(calculator);
            //calculator = new LoggerDecorator(calculator);

            //Пример билдера раширения для удобного составления цепочки дерорторов
            calculator = new DecoratorBuilder(calculator)
                .WithTimer()
                .WithLogger()
                .Build();

            calculator.SetFunction((x) => x*2);
            var result = calculator.Calculate(2);
            Console.WriteLine(result);
        }

        public static void FlyweightExample()
        {
            var w1 = WindowsFactory.GetWindows("Приветствие", "Добро пожаловать в пример");
            w1.Show();

            var w2 = WindowsFactory.GetWindows("Еще какое-то окно", "Какой то текст");
            w2.Show();

            var w3 = WindowsFactory.GetWindows("WARNING", "Опасное предупреждение");
            w3.Show();

            var w4 = WindowsFactory.GetWindows("WARNING", "Самое опасное предупреждение");
            w4.Show();

            var w5 = WindowsFactory.GetWindows("Приветствие", "И снова здраствуйте");
            w5.Show();
        }
    }
}
