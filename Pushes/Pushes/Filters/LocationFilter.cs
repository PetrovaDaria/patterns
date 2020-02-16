using System;

namespace Pushes
{
    public class LocationFilter : IFilter
    {
        public bool Filter(System system, Push push)
        {
            var distance = Math.Sqrt(Math.Pow(system.X - push.X, 2) + Math.Pow(system.Y - push.Y, 2));
            return distance > push.Radius ;
        }
    }
}
