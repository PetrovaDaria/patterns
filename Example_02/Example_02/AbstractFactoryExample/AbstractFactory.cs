namespace Example_02.AbstractFactoryExample
{

    #region Interfaces

    public interface ILunchFactory
    {
        IHotDish CreateHotDish();
        IDessert CreateDessert();
    }

    public interface IHotDish
    {
        string Name { get; }
    }

    public interface IDessert
    {
        string Name { get; }
    }

    #endregion

    #region Monday Lunch

    public class MondayFactory : ILunchFactory
    {
        public IHotDish CreateHotDish()
        {
            return new Puree();
        }

        public IDessert CreateDessert()
        {
            return new Muffin();
        }
    }

    public class Puree : IHotDish
    {
        public string Name => "Пюрешка с котлетками";
    }

    public class Muffin : IDessert
    {
        public string Name => "Мафин";
    }

    #endregion

    #region Tuesday Lunch

    public class TuesdayFactory : ILunchFactory
    {
        public IHotDish CreateHotDish()
        {
            return new Pasta();
        }

        public IDessert CreateDessert()
        {
            return new IceCream();
        }
    }

    public class Pasta : IHotDish
    {
        public string Name => "Макароны по-флотски";
    }

    public class IceCream : IDessert
    {
        public string Name => "Мороженое";
    }

    #endregion
}