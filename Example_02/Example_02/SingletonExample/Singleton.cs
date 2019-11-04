namespace Example_02.SingletonExample
{
    public class Singleton
    {
        private Singleton() { }

        public static readonly Singleton Instance = new Singleton();
    }
}