using System.Collections.Generic;
using NotImplementedException = System.NotImplementedException;

namespace Pushes
{
    public class GenderPushBuilder : Builder
    {
        protected override List<string> NecessaryFields => new List<string> { "gender" };
        protected override void setProperties()
        {
            SetGender();
            SetFilters(new List<IFilter> {new GenderFilter()});
        }
    }
}
