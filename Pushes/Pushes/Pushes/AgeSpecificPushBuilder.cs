using System.Collections.Generic;

namespace Pushes
{
    public class AgeSpecificPushBuilder : Builder
    {
        protected override List<string> NecessaryFields =>
            new List<string> { "age", "expiry_date" };

        protected override void setProperties()
        {
            SetAge();
            SetExpiry();
            SetFilters(new List<IFilter> { new AgeFilter(), new ExpiryFilter() });
        }
    }
}
