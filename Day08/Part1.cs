using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc;

internal class Part1
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

            var regex = new Regex(@"[A-Z]+");
            var parts = regex.Matches(line);
            var curNode = new Node { Left = parts[1].Value, Right = parts[2].Value };
            map.Add(parts[0].Value, curNode);

        }

        long steps = 0;
        var currentPlace = "AAA";
        var currentNodes = map[currentPlace];
        var loopDetection = new List<string>();
        while (true)
        {
            //Console.Write(currentPlace.Key);
            if (currentPlace == "ZZZ") { break; } // done
            int pathStep = Convert.ToInt32(steps % path.Length);
            if (path[pathStep] == 'L')
            {
                currentPlace = currentNodes.Left;
                //Console.WriteLine(" :: Left {0} :: " +  currentPlace.Key, (steps % path.Length).ToString());
            }
            else
            {
                currentPlace = currentNodes.Right;
            }
            currentNodes = map[currentPlace];
            steps++;

        }


        Console.WriteLine(steps);
        

    }

    record Node
    {
        public string Left;
        public string Right;

    }

}

