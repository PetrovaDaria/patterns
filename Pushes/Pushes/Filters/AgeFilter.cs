namespace Pushes
{
    public class AgeFilter : IFilter
    {
        public bool Filter(System system, Push push)
        {
            return system.Age < push.Age;
        }
    }
}
