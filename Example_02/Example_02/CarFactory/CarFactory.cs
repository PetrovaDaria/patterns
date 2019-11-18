namespace Example_02.CarFactory
{
    public interface ICarBody
    {
        int Width { get; }
        int Height { get; }
    }

    public interface ICarEngine
    {
        int HorsePower { get; }
    }

    public interface ICarCabin
    {
        int Capacity { get; }
    }

    public interface ICarFactory
    {
        ICarBody CreateBody();

        ICarEngine CreateEngine();

        ICarCabin CreateCabin();
    }

    public class BMWFactory : ICarFactory
    {
        public ICarBody CreateBody()
        {
            return new BMWBody();
        }

        public ICarEngine CreateEngine()
        {
            return new BMWEngine();
        }

        public ICarCabin CreateCabin()
        {
            return new BMWCabin();
        }
    }

    public class AudiFactory : ICarFactory
    {
        public ICarBody CreateBody()
        {
            return new AudiBody();
        }

        public ICarEngine CreateEngine()
        {
            return new AudiEngine();
        }

        public ICarCabin CreateCabin()
        {
            return new AudiCabin();
        }
    }

    public class BMWBody : ICarBody
    {
        public int Width => 250;
        public int Height => 100;
    }

    public class AudiBody : ICarBody
    {
        public int Width => 180;
        public int Height => 80;
    }

    public class BMWEngine : ICarEngine
    {
        public int HorsePower => 250;
    }

    public class AudiEngine : ICarEngine
    {
        public int HorsePower => 180;
    }

    public class BMWCabin : ICarCabin
    {
        public int Capacity => 8;
    }

    public class AudiCabin : ICarCabin
    {
        public int Capacity => 5;
    }
}
