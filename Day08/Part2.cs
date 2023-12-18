using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc;

internal class Part2
{
    public static void Run()
    {
        var inputFile = File.OpenText("input.txt");

        var map = new Dictionary<string, Node>();
        var path = inputFile.ReadLine();

        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            if (line.Length == 0) { continue; }

            var regex = new Regex(@"[0-9A-Z]+");
            var parts = regex.Matches(line);
            var curNode = new Node { Left = parts[1].Value, Right = parts[2].Value };
            map.Add(parts[0].Value, curNode);

        }

        long steps = 0;

        var ghostPlaces = new List<string>();
        var ghostPaths = new List<long>();
        //find starts
        foreach (var spot in map.Keys)
        {
            if (spot[2] == 'A' )
            {
                ghostPlaces.Add(spot);
                ghostPaths.Add(0);
            }
        }

        while (true)
        {
            
            
            int pathStep = Convert.ToInt32(steps % path.Length);

            for (int i = 0; i<ghostPlaces.Count; i++)
            {
                if (ghostPlaces[i][2] == 'Z')
                {
                    ghostPaths[i] = steps;
                }
                if (path[pathStep] == 'L')
                {
                    ghostPlaces[i] = map[ghostPlaces[i]].Left;
                } else
                {
                    ghostPlaces[i] = map[ghostPlaces[i]].Right;
                }
            }

            if (ghostPaths.Where(g => g == 0).Count() == 0) { break; }

            steps++;

        }

        long result = ghostPaths[0];
        for (int i = 1; i<ghostPaths.Count; i++)
        {
            result = lcm(result, ghostPaths[i]);

        }
        Console.WriteLine(result);

    }

    private static long gcd(long a, long b)
    {
        if(b == 0)
        {
            return a;
        }
        long r = a % b;
        return gcd(b, r);
    }

    private static long lcm(long a, long b)
    {
        return a * b / gcd(a, b);
    }

    record Node
    {
        public string Left;
        public string Right;

    }

}

