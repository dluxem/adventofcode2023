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

        var hands = new Dictionary<string, int>();

        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            var parts = line.Split(" ");
            hands.Add(parts[0], Convert.ToInt32(parts[1]));
        }

        var sortedHands = CardSort.BubbleSort(hands.Keys.ToList<string>());

        var total = 0;
        var place = 0;
        foreach (var hand in sortedHands)
        {
            place++;
            var bid = hands[hand];
            total += place * bid;
        }

        Console.WriteLine(total);
        

    }

}

