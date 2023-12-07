using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc;

internal class Part2
{
    private static Dictionary<int, int> cardWins = new Dictionary<int, int>();
    private static Dictionary<int, int> cardsToProcess = new Dictionary<int, int>();

    public static void Run()
    {
        var inputFile = File.OpenText("input.txt");
        var cardNumber = 0;
        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            cardNumber++;

            var parts = line.Split(new char[] { ':', '|' }, StringSplitOptions.RemoveEmptyEntries);
            string[] winning = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var correct = 0;
            foreach (var item in parts[2].Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {
                if (winning.Contains(item)) { correct++; }
            }
            cardWins.Add(cardNumber, correct);
        }

        for (int i = cardNumber; i >0; i--)
        {
            cardsToProcess.Add(i, ProcessCards(i));
        }

        var total = 0;
        foreach (var card in cardsToProcess)
        {
            total += card.Value;
        }
        Console.WriteLine(total);

    }

    private static int ProcessCards(int q)
    {
        var count=1;
        var cardNumber = q;
        var wins = cardWins[cardNumber];
        for (int i = cardNumber+1; i < cardNumber+1+wins ; i++)
        {
            if (cardsToProcess[i] != 0) { count += cardsToProcess[i]; }
        }
        return count;

    }

}

