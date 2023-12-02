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

        int redMax = 12;
        int greenMax = 13;
        int blueMax = 14;

        var total = 0;
        while (!inputFile.EndOfStream)
        {
            string line = inputFile.ReadLine();
            if (line == null) { continue; }
            string[] parts = line.Split(new char[] {',',':',' ',';'}, StringSplitOptions.RemoveEmptyEntries);
            
            var gameNum = Convert.ToInt32(parts[1]);
            var badGame = false;
            for (int i = 2; i <= parts.Length-2; i=i+2)
            {
                var max = 0;
                switch (parts[i+1])
                {
                    case "red":
                        max = redMax; break;
                    case "blue":
                        max = blueMax; break;
                    case "green":
                        max = greenMax; break;
                    default:
                        break;
                }
                if (Convert.ToInt32(parts[i]) > max)
                {
                    badGame = true;
                    break; //for
                }
            }
            if (!badGame) {
                total += gameNum;
            }
        }
        Console.WriteLine("Part1 Answer");
        Console.WriteLine(total);
        

    }

}

