using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc;

internal class Part2
{
    public static void Run()
    {
        var inputFile = File.OpenText("input.txt");

        var total = 0;
        while (!inputFile.EndOfStream)
        {
            string line = inputFile.ReadLine();
            if (line == null) { continue; }
            string[] parts = line.Split(new char[] { ',', ':', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);

            var gameNum = Convert.ToInt32(parts[1]);
            var redMax = 0;
            var greenMax = 0;
            var blueMax = 0;
            for (int i = 2; i <= parts.Length - 2; i = i + 2)
            {
                var value = Convert.ToInt32(parts[i]);
                switch (parts[i + 1])
                {
                    case "red":
                        if (value > redMax)
                        {
                            redMax = value;
                        }
                        break;
                    case "blue":
                        if (value > blueMax)
                        {
                            blueMax = value;
                        }
                        break;
                    case "green":
                        if (value > greenMax)
                        {
                            greenMax = value;
                        }
                        break;
                    default:
                        break;
                }
            }
            total += (redMax * blueMax * greenMax);

        }
        Console.WriteLine("Part1 Answer");
        Console.WriteLine(total);


    }

}

