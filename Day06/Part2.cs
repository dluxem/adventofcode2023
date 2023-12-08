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


        var lines = inputFile.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        var regex = new Regex(@"[\d+\s+]+");
        var times = regex.Matches(lines[0]).ToList().Select(x => Convert.ToInt64(x.Value.Replace(" ",String.Empty))).ToList();
        var distances = regex.Matches(lines[1]).ToList().Select(x => Convert.ToInt64(x.Value.Replace(" ", String.Empty))).ToList();

        var total = 1;

        for (int i = 0; i < times.Count; i++)
        {
            long tMax = times[i];
            long dMin = distances[i];
            var goodCount = 0;
            for (long tCharge = 0; tCharge <= times[i]; tCharge++)
            {
                if ((tCharge * (tMax - tCharge)) > dMin)
                {
                    //Console.WriteLine("GOOD tM {0} / tC {1} / dM {2}", tMax, tCharge, dMin);
                    goodCount++;
                }
            }
            total = total * goodCount;

        }

        Console.WriteLine(total);


    }

}

