namespace Pushes
{
    public class GenderFilter : IFilter
    {
        public bool Filter(System system, Push push)
        {
            return system.Gender != push.Gender;
        }
    }
}
