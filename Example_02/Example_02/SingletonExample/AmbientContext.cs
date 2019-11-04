using System;

namespace Example_02.SingletonExample
{
    public interface ILogger
    {
        void Log(string message);
    }
    
    public class ConsoleLogger : ILogger
    {
        private readonly ConsoleColor _color;

        public ConsoleLogger(ConsoleColor color = ConsoleColor.White)
        {
            _color = color;
        }

        public void Log(string message)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    public class LoggerSingleton
    {
        private static ILogger _logger = new ConsoleLogger();

        public static ILogger Logger => _logger;

        public static void SetLogger(ILogger logger)
        {
            _logger = logger;
        }
    }

    public class Runner
    {
        public static void Run()
        {
            //var instance1 = Singleton.Instance;
            //var instance2 = DoubleCheckSingleton.Instance;

            var logger = LoggerSingleton.Logger;
            logger.Log("Запуск по умолчанию");

            LoggerSingleton.SetLogger(new ConsoleLogger(ConsoleColor.Green));

            logger = LoggerSingleton.Logger;
            logger.Log("Запуск с изменеными настройками");
        }
    }
}