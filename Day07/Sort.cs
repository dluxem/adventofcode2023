using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc;

static internal class CardSort
{
    static private readonly string cardOrder = "23456789TJQKA";

    public static IList<string> BubbleSort(IList<string> hands)
    {
        var n = hands.Count;
        for (int i = 0; i < n-1; i++)
        {
            for (int j = 0;  j < n-1; j++)
            {
                
                if (AGreaterThanB(hands[j], hands[j+1]))
                {
                    var item = hands[j];
                    hands[j] = hands[j+1];
                    hands[j+1] = item;
                }
                
            }


        }
        return hands;
    }

    public static bool AGreaterThanB(string a, string b)
    {
        var strengthA = HandStrength(a);
        var strengthB = HandStrength(b);
        if (strengthA > strengthB) {  return true; }
        if (strengthB > strengthA) { return false; }
        if (strengthA == strengthB)
        {
            if (SameAGreaterThanSameB(a, b)) { return true; }
        }
        return false;
    }

    private static int HandStrength(string hand)
    {
        var charList = hand.ToCharArray().ToList();
        var counted = charList.GroupBy(x => x).Select(x => new
        {
            Count = x.Count(),
            Name = x.Key
        }).OrderByDescending(x => x.Count);

        var three = false;
        var pair = false;
        var twoPair = false;

        foreach (var c in counted)
        {
            if (c.Count == 5) { return 6; } // 5 of kind
            if (c.Count == 4) { return 5; } // 4 of kind
            if (c.Count == 3) { three = true; }
            if (c.Count == 2)
            {
                if (three) { return 4; } // full house
                if (pair) { twoPair = true; }
                pair = true;
            }
        }
        if (three) { return 3;  } // 3 of kind
        if (twoPair) { return 2; } // 2 pair
        if (pair) { return 1; }
        return 0; // high
    }

    private static bool SameAGreaterThanSameB(string a, string b)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == b[i]) { continue; }
            var aNum = cardOrder.IndexOf(a[i]);
            var bNum = cardOrder.IndexOf(b[i]);
            if (aNum > bNum) { return true; }
            if (aNum < bNum) { return false; }
        }
        return true;

    }

}
