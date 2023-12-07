using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc;

internal class Part1
{
    public static void Run()
    {
        var inputFile = File.OpenText("input.txt");

        var total = 0;
        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            var parts = line.Split(new char[] { ':', '|' },StringSplitOptions.RemoveEmptyEntries);
            string[] winning = parts[1].Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var correct = 0;
            foreach (var item in parts[2].Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {
                if (winning.Contains(item)) { correct++;  }
            }
            if (correct > 0) { total += Power(2, correct-1); }

        }


        Console.WriteLine(total);
        

    }

    public static int Power(int x, int power)
    {
        int result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= x;
        }
        return result;
    }

}

