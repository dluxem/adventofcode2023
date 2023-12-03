using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc;

internal class Part1
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
            var matches = Regex.Match(line, "(\\d+)");
            while (matches.Success)
            {
                var result = checkSymbols(matches.Index, (matches.Index + matches.Length), lineCount, lineLength);
                if (result)
                {
                    total += Convert.ToInt32(matches.Value);
                }
                matches = matches.NextMatch();
            }
            lineCount++;
        }


        Console.WriteLine(total);
        

    }

    private static bool checkSymbols(int start, int end, int lineNumber, int maxLineLength)
    {
        if (start > 0) { start = start - 1; }
        if (end < maxLineLength-1) { end = end + 1; }

        var checkString = "";
        if (lineNumber > 0) // n-1
        {
            checkString = checkString + schematic[lineNumber - 1].Substring(start, end - start);
        }
        checkString = checkString + schematic[lineNumber].Substring(start, end - start);
        if (lineNumber < schematic.Count - 1)
        {
            checkString = checkString + schematic[lineNumber + 1].Substring(start, end - start);
        }

        checkString = Regex.Replace(checkString, "[\\.\\d]*", "");
        if (checkString.Length > 0) { return  true; }
        else { return false; }
    }

}

