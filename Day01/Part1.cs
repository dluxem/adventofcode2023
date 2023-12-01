using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace aoc;

internal class Part1
{
    public static void Run()
    {
        var inputFile = File.OpenText("input.txt");

        int sum = 0;

        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            var regex = new Regex(@"(\d)");
            var matches = regex.Matches(line);
            var int10 = Convert.ToInt32(matches[0].Value);
            var int1 = Convert.ToInt32(matches[matches.Count - 1].Value);
            sum = sum + (int10 * 10) + int1;
            
        }


        Console.WriteLine(sum);
        

    }

}

