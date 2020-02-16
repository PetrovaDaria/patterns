using System;
using System.Collections.Generic;

namespace TechnologyCircles
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Solution2();
        }

        private static void Solution2()
        {
            var graph = new Dictionary<string, HashSet<string>>();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var technologies = Console.ReadLine().Split(' ');
                var firstTechnology = technologies[0];
                if (!graph.ContainsKey(firstTechnology))
                {
                    graph[firstTechnology] = new HashSet<string>();
                }
                for (var j = 1; j < technologies.Length; j++ )
                {
                    var currentTechnology = technologies[j];
                    if (!graph.ContainsKey(currentTechnology))
                    {
                        graph[currentTechnology] = new HashSet<string>();
                    }
                    graph[firstTechnology].Add(currentTechnology);
                    graph[currentTechnology].Add(firstTechnology);
                }
            }

            var components = 0;
            var seen = new HashSet<string>();
            foreach (var technology in graph.Keys)
            {
                if (!seen.Contains(technology))
                {
                    var stack = new Stack<string>();
                    stack.Push(technology);
                    seen.Add(technology);
                    components += 1;
                    while (stack.Count > 0)
                    {
                        var current = stack.Pop();
                        foreach (var neighbor in graph[current])
                        {
                            if (!seen.Contains(neighbor))
                            {
                                seen.Add(neighbor);
                                stack.Push(neighbor);
                            }
                        }
                    }
                }
            }

            Console.WriteLine(components);
        }

        private static void Solution1()
        {
            var superSets = new List<HashSet<string>>();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++) {
                var technologies = Console.ReadLine().Split(' ');
                var possibleSuperSets = new List<int>();

                for (var j = 0; j < superSets.Count; j++) {
                    var superSet = superSets[j];
                    foreach (var technology in technologies) {
                        if (superSet.Contains(technology)) {
                            possibleSuperSets.Add(j);
                            break;
                        }
                    }
                }

                if (possibleSuperSets.Count == 0) {
                    var superSet = new HashSet<string>();
                    foreach (var technology in technologies) {
                        superSet.Add(technology);
                    }
                    superSets.Add(superSet);
                } else {
                    var firstSuperSet = superSets[possibleSuperSets[0]];
                    foreach (var technology in technologies) {
                        firstSuperSet.Add(technology);
                    }

                    if (possibleSuperSets.Count > 1) {
                        for (var j = possibleSuperSets.Count - 1; j > 0; j--) {
                            var superSetIndex = possibleSuperSets[j];
                            var superSet = superSets[superSetIndex];
                            firstSuperSet.UnionWith(superSet);
                            /*
                            foreach (var technology in superSet) {
                                firstSuperSet.Add(technology);
                            }
                            */
                            superSets.RemoveAt(superSetIndex);
                        }
                    }
                }
            }
            Console.WriteLine(superSets.Count);
        }
    }
}
