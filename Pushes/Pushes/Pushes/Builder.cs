using System;
using System.Collections.Generic;

namespace Pushes
{
    public abstract class Builder
    {
        protected Push push;
        protected Dictionary<string, string> Parameters;
        protected abstract List<string> NecessaryFields { get; }

        protected void SetFilters(List<IFilter> filters)
        {
            push.Filters = filters;
        }

        protected void SetOs()
        {
            push.Os = int.Parse(Parameters["os_version"]);
        }

        protected void SetAge()
        {
            push.Age = int.Parse(Parameters["age"]);
        }

        protected void SetX()
        {
            push.X = float.Parse(Parameters["x_coord"]);
        }

        protected void SetY()
        {
            push.Y = float.Parse(Parameters["y_coord"]);
        }

        protected void SetRadius()
        {
            push.Radius = int.Parse(Parameters["radius"]);
        }

        protected void SetGender()
        {
            push.Gender = Parameters["gender"];
        }

        protected void SetExpiry()
        {
            push.Expiry = long.Parse(Parameters["expiry_date"]);
        }

        protected void SetLocation()
        {
            SetX();
            SetY();
            SetRadius();
        }

        protected abstract void setProperties();

        public Push Build(Dictionary<string, string> parameters)
        {
            foreach (var field in NecessaryFields)
            {
                if (!parameters.ContainsKey(field))
                {
                    throw new Exception("Parameters don't contain necessary field");
                }
            }
            push = new Push();
            push.Text = parameters["text"];
            Parameters = parameters;
            setProperties();
            return push;
        }
    }
}
