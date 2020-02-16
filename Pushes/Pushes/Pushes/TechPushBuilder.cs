using System.Collections.Generic;
using NotImplementedException = System.NotImplementedException;

namespace Pushes
{
    public class TechPushBuilder : Builder
    {
        protected override List<string> NecessaryFields => new List<string> { "os_version" };
        protected override void setProperties()
        {
            SetOs();
            SetFilters(new List<IFilter> {new OsFilter()});
        }
    }
}
