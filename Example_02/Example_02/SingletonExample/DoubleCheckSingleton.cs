namespace Example_02.SingletonExample
{
    public class DoubleCheckSingleton
    {
        private DoubleCheckSingleton() { }

        private static volatile DoubleCheckSingleton _instance;
        private static readonly object _lock = new object();

        public static DoubleCheckSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoubleCheckSingleton();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}