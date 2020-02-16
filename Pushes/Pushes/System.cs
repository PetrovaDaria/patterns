using System.Collections.Generic;

namespace Pushes
{
    public class System
    {
        public long Time;
        public float X;
        public float Y;
        public int Age;
        public string Gender;
        public int Os;

        public System(Dictionary<string, string> parameters)
        {
            Time = long.Parse(parameters["time"]);
            X = float.Parse(parameters["x_coord"]);
            Y = float.Parse(parameters["y_coord"]);
            Age = int.Parse(parameters["age"]);
            Os = int.Parse(parameters["os_version"]);
            Gender = parameters["gender"];
        }
    }
}
