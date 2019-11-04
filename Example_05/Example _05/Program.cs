using System;
using Example__05.ChatClient;
using Example__05.Decorator;
using Example__05.Flyweight;

namespace Example__05
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatClientExample();
            //DecoratorExample();
            //FlyweightExample();

            Console.ReadKey();
        }

        public static void ChatClientExample()
        {
            IChatClient chatClient1 = new ChatClient.ChatClient("first");
            IChatClient chatClient2 = new ChatClient.ChatClient("second");
            // chatClient1 = new NameShadowDecorator(chatClient1);
            chatClient2 = new CypherDecorator(chatClient2);

            var message1 = new Message(chatClient1.Login, chatClient2.Login, "hi, second");
            var message2 = new Message(chatClient1.Login, chatClient2.Login, "how are you?");
            chatClient1.SendMessage(message1);
            chatClient1.SendMessage(message2);

            var chatClient2Messages = chatClient2.GetMessages();
            chatClient2Messages.ForEach(Console.WriteLine);

            var message3 = new Message(chatClient2.Login, chatClient1.Login, "HI! I'm fine!");
            chatClient2.SendMessage(message3);

            var chatClient1Messages = chatClient1.GetMessages();
            chatClient1Messages.ForEach(Console.WriteLine);
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
