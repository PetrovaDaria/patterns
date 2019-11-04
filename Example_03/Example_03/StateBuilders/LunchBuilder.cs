using Example_03.StateBuilders.Enums;

namespace Example_03.StateBuilders
{
    //билдер возвращает не себя, а другой билдер
    //пока не заполним нужные поля, возвращает билдер первого уровня
    //заполнили поля - вернулся билдер второго уровня
    //compile-time валдиация
    public class LunchBuilder
    {
        public LunchSideDishBuilder AddEntree(EntreeType entree)
        {
            return new LunchSideDishBuilder(entree);
        }

        public class LunchSideDishBuilder
        {
            private readonly EntreeType _entree;

            public LunchSideDishBuilder(EntreeType entree)
            {
                _entree = entree;
            }

            public FinalLanchBuilder AddSideDish(SideDishType sideDish)
            {
                return new FinalLanchBuilder(_entree, sideDish);
            }
        }

        public class FinalLanchBuilder
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
}
