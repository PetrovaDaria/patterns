using System.Collections.Generic;
using NotImplementedException = System.NotImplementedException;

namespace Pushes
{
    public class GenderAgePushBuilder : Builder
    {
        protected override List<string> NecessaryFields =>
            new List<string> { "age", "gender" };

        protected override void setProperties()
        {
            SetAge();
            SetGender();
            SetFilters(new List<IFilter> { new AgeFilter(), new GenderFilter() });
        }
    }
}
