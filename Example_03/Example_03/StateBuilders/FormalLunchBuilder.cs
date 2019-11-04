using Example_03.StateBuilders.Enums;

namespace Example_03.StateBuilders
{
    public class FormalLunchBuilder
    {
        public ILunchSideDishBuilder AddEntree(EntreeType entree)
        {
            return new LunchSideDishBuilder(entree);
        }

        //private класс внутри public класс, реализующий public интерфейс
        private class LunchSideDishBuilder : ILunchSideDishBuilder
        {
            private readonly EntreeType _entree;

            public LunchSideDishBuilder(EntreeType entree)
            {
                _entree = entree;
            }

            public IFinalLanchBuilder AddSideDish(SideDishType sideDish)
            {
                return new FinalLanchBuilder(_entree, sideDish);
            }
        }

        private class FinalLanchBuilder : IFinalLanchBuilder
        {
            private readonly EntreeType _entree;
            private readonly SideDishType _sideDish;

            public FinalLanchBuilder(EntreeType entree, SideDishType sideDish)
            {
                _entree = entree;
                _sideDish = sideDish;
            }

            public string Build => $"{_entree}; {_sideDish}";
        }
    }

    public interface ILunchSideDishBuilder
    {
        IFinalLanchBuilder AddSideDish(SideDishType sideDish);
    }

    public interface IFinalLanchBuilder
    {
        string Build { get; }
    }
}
