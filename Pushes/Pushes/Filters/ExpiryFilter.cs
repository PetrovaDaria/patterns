namespace Pushes
{
    public class ExpiryFilter : IFilter
    {
        public bool Filter(System system, Push push)
        {
            return push.Expiry < system.Time;
        }
    }
}
