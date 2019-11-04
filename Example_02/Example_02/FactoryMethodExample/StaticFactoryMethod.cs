using System;
using Example_02.AbstractFactoryExample;

namespace Example_02.FactoryMethodExample
{
    public static class LunchFactoryHelper
    {
        public static ILunchFactory Create(WeekDay weekDay)
        {
            switch (weekDay)
            {
                case WeekDay.Monday:
                    return new MondayFactory();
                case WeekDay.Tuesday:
                    return new TuesdayFactory();
            }
            throw new NotSupportedException();
        }
    }
}