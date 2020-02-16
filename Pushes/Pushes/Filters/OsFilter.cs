namespace Pushes
{
    public class OsFilter : IFilter
    {
        public bool Filter(System system, Push push)
        {
            return system.Os > push.Os;
        }
    }
}
