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


        var lines = inputFile.ReadToEnd().Split(new string[] { "\r\n" },StringSplitOptions.RemoveEmptyEntries);
        var regex = new Regex(@"\d+");
        var times = regex.Matches(lines[0]).ToList().Select(x => Convert.ToInt32(x.Value)).ToList();
        var distances = regex.Matches(lines[1]).ToList().Select(x => Convert.ToInt32(x.Value)).ToList();

        var total = 1;

        for (int i = 0; i < times.Count; i++)
        {
            var tMax = times[i];
            var dMin = distances[i];
            var goodCount = 0;
            for (int tCharge = 0; tCharge <= times[i]; tCharge++)
            {
                if (tCharge * tMax - tCharge * tCharge > dMin)
                {
                    // Console.WriteLine("GOOD tM {0} / tC {1} / dM {2}", tMax, tCharge, dMin);
                    goodCount++;
                }
            }
            total = total * goodCount;

        }

        Console.WriteLine(total);
        

    }

}

