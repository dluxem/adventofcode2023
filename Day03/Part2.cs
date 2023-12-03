using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc;

internal class Part2
{
    static List<string> schematic = new List<string>();

    public static void Run()
    {
        var inputFile = File.OpenText("input.txt");
        var total = 0;

        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            schematic.Add(line);
        }

        var lineCount = 0;
        foreach (var line in schematic)
        {
            var lineLength = line.Length;
            var matches = Regex.Match(line, "(\\*)");
            while (matches.Success)
            {
                total += checkGears(matches.Index, lineCount);
                matches = matches.NextMatch();
            }
            lineCount++;
        }


        Console.WriteLine(total);


    }

    private static int checkGears(int index, int lineNumber)
    {
        List<int> nearby = new List<int>();

        //above
        if (lineNumber > 0) {
            var m = Regex.Match(schematic[lineNumber-1],"(\\d+)");
            while (m.Success)
            {
                if (index >= m.Index-1 && index <= m.Index+m.Value.Length)
                {
                    nearby.Add(Convert.ToInt32(m.Value));
                }
                m = m.NextMatch();
            }
        }

        //below
        if (lineNumber < schematic.Count-1)
        {
            var m = Regex.Match(schematic[lineNumber + 1], "(\\d+)");
            while (m.Success)
            {
                if (index >= m.Index - 1 && index <= m.Index + m.Value.Length)
                {
                    nearby.Add(Convert.ToInt32(m.Value));
                }
                m = m.NextMatch();
            }
        }

        // same line
        var mSame = Regex.Match(schematic[lineNumber], "(\\d+)");
        while (mSame.Success)
        {
            if (index == mSame.Index - 1 || index == mSame.Index + mSame.Value.Length)
            {
                nearby.Add(Convert.ToInt32(mSame.Value));
            }
            mSame = mSame.NextMatch();
        }

        var results = nearby.Where<int>(i => i >= 0).ToList();
        if (results.Count() != 2 ) {
            return 0;
        }
        else
        {
            // Console.WriteLine("Line: {0}, Index: {1}, Gears: {2}, {3}", lineNumber, index, results[0], results[1]);
            return results[0] * results[1];
        }

    }

}

