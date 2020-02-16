using System.Collections.Generic;
using NotImplementedException = System.NotImplementedException;

namespace Pushes
{
    public class LocationAgePushBuilder : Builder
    {
        protected override List<string> NecessaryFields =>
            new List<string>{"age", "x_coord", "y_coord", "radius"};

        protected override void setProperties()
        {
            SetAge();
            SetLocation();
            SetFilters(new List<IFilter> {new LocationFilter(), new AgeFilter()});
        }
    }
}
