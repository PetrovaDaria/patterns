using System;
using System.Collections.Generic;

namespace Pushes
{
    internal class Program
    {
        private static Dictionary<string, Builder> builders = new Dictionary<string, Builder>
        {
            { "AgeSpecificPush",  new AgeSpecificPushBuilder() },
            { "GenderAgePush", new GenderAgePushBuilder() },
            { "GenderPush", new GenderPushBuilder() },
            { "LocationAgePush", new LocationAgePushBuilder() },
            { "LocationPush", new LocationPushBuilder() },
            { "TechPush", new TechPushBuilder() }
        };

        public static void Main(string[] args)
        {
            var systemParamsCount = 6;
            var parameters = new Dictionary<string, string>();
            for (var i = 0; i < systemParamsCount; i++)
            {
                var line = Console.ReadLine().Split(' ');
                var parameter = line[0];
                var value = line[1];
                parameters[parameter] = value;
            }
            var system = new System(parameters);

            var pushes = new List<Push>();
            var pushesCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < pushesCount; i++)
            {
                var pushParamsCount = int.Parse(Console.ReadLine());
                var pushParams = new Dictionary<string, string>();
                for (var j = 0; j < pushParamsCount; j++)
                {
                    var line = Console.ReadLine().Split(' ');
                    var parameter = line[0];
                    var value = line[1];
                    pushParams[parameter] = value;
                }
                var push = GetPush(system, pushParams);
                pushes.Add(push);
            }

            var allFiltered = true;

            foreach (var push in pushes)
            {
                if (!push.Filter(system))
                {
                    allFiltered = false;
                    Console.WriteLine(push.Text);
                }
            }

            if (allFiltered)
            {
                Console.WriteLine(-1);
            }
        }

       private static Push GetPush(System system, Dictionary<string, string> parameters)
       {
           return builders[parameters["type"]].Build(parameters);
       }
    }
}
