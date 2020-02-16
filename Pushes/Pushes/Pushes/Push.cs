using System.Collections.Generic;

namespace Pushes
{
    public class Push
    {
        public string Text;
        public List<IFilter> Filters;

        public int Age;
        public float X;
        public float Y;
        public int Radius;
        public string Gender;
        public int Os;
        public long Expiry;

        public bool Filter(System system)
        {
            foreach (var filter in Filters)
            {
                if (filter.Filter(system, this))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
