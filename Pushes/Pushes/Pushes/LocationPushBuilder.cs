using System.Collections.Generic;
using NotImplementedException = System.NotImplementedException;

namespace Pushes
{
    public class LocationPushBuilder : Builder
    {
        protected override List<string> NecessaryFields =>
            new List<string> { "x_coord", "y_coord", "radius", "expiry_date" };

        protected override void setProperties()
        {
            SetLocation();
            SetExpiry();
            SetFilters(new List<IFilter> { new LocationFilter(), new ExpiryFilter() });
        }
    }
}
