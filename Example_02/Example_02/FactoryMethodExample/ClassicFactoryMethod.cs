using System;
using System.IO;
using System.Net.Sockets;

namespace Example_02.FactoryMethodExample
{
    public abstract class LoggerBase
    {
        protected abstract StreamWriter GetStreamWriter();

        public void Error(Exception ex)
        {
            var streamWriter = GetStreamWriter();
            streamWriter.Write($"Произошло исключение: {ex.Message}");
            //...
        }
    }

    public class FileLogger : LoggerBase
    {
        private const string FileName = "log.txt";

        protected override StreamWriter GetStreamWriter()
        {
            var fileStream = File.OpenWrite(FileName);
            return new StreamWriter(fileStream);
        }
    }

    public class TcpLogger : LoggerBase
    {
        private const string HostName = "localhost";
        private const int Port = 9200;

        protected override StreamWriter GetStreamWriter()
        {
            var tcpClient = new TcpClient(HostName, Port);
            var tcpStream = tcpClient.GetStream();
            return new StreamWriter(tcpStream);
        }
    }
}